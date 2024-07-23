using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int width; // Number of tile columns
    [SerializeField] private int height; // Number of tile rows

    [SerializeField, Range(0, 100)] private int fillPercent;
    [SerializeField] private int smoothSteps;

    [SerializeField, Range(0, 8)] private int filledNeighborThreshold = 4;

    [SerializeField] private int minFilledRegionSize;
    [SerializeField] private bool singleCavern;

    [SerializeField] private string seed;
    [SerializeField] private bool useRandomSeed;

    public bool autoUpdate = false;
    
    [SerializeField] private MapDisplay mapDisplay;

    Vector2Int[] directions = { new(0, -1), new(0, 1), new(-1, 0), new(1, 0), new (-1, -1), new (-1, 1), new (1, -1), new Vector2Int(1, 1) };
    Vector2Int[] orthogonalDirections = { new(0, -1), new(0, 1), new(-1, 0), new(1, 0) };

    void Start()
    {
        Generate();
    }

    // Generate and display a map
    public void Generate()
    {
        if (useRandomSeed)
        {
        // Generate random seed
            seed = Time.time.ToString();
        }
        // Seed the random generator
        System.Random rng = new System.Random(seed.GetHashCode());

        bool[,] map = GenerateMap(rng);
        
        mapDisplay.DisplayMap(map);

    }

    private bool[,] GenerateMap(System.Random rng)
    {
        var map = new bool[width, height];
        RandomFill(map, rng);

        // Repeatedly smooth the map
        for (int i = 0; i < smoothSteps; i++)
        {
            map = SmoothMap(map);
        }

        var emptyRegions = GetRegions(map, false);

        // If there is more than 1 empty region, fill all other empty regions except the largest region
        if (singleCavern && emptyRegions.Count > 1)
        {
            int largestSize = emptyRegions.Max(region => region.Count);
            PruneRegions(map, emptyRegions, largestSize);
        }

        // Remove filled regions that are smaller than minimum size
        var filledRegions = GetRegions(map, true);
        PruneRegions(map, filledRegions, minFilledRegionSize);

        return map;
    }

    // Remove regions that are smaller than the threshold size
    // Regions are removed by inverting their bool value
    private void PruneRegions(bool[,] map, List<List<Vector2Int>> regions, int minRegionSize)
    {
        // Iterate over the list in reverse so that we can remove from it
        for (int i = regions.Count - 1; i >= 0; i--)
        {
            var region = regions[i];
            if (region.Count < minRegionSize)
            {
                InvertRegion(map, region);
                regions.Remove(region);
            }
        }
    }

    // Invert the boolean value for every cell in the given set 
    private void InvertRegion(bool[,] map, List<Vector2Int> cells)
    {
        foreach (var cell in cells)
        {
            map[cell.x, cell.y] = !map[cell.x, cell.y];
        }
    }

    private void RandomFill(bool[,] map, System.Random rng)
    {
        // Initialize map with random boolean values based on density percentage
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Map boundaries are always filled
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    map[x, y] = true;
                }
                else
                {
                    map[x, y] = rng.Next(0, 100) < fillPercent;
                }
            }
        }
    }

    // Smooth the map by giving neighbors a higher tendency to be the same
    private bool[,] SmoothMap(bool[,] map)
    {
        // Create a new map so that we can read from the current map and write to the new map
        bool[,] mapCopy = new bool[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Boundary walls should remain
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    mapCopy[x, y] = true;
                    continue;
                }

                // If the cell has more than "neighborThreshold" filled neighbors,
                // then fill the cell
                int filledNeighbors = CountFilledNeighbors(x, y, map);
                if (filledNeighbors > filledNeighborThreshold)
                {
                    mapCopy[x, y] = true;
                    // If the cell has less than "neighborThreshold" filled neighbors,
                    // then clear the cell
                }
                else if (filledNeighbors < filledNeighborThreshold)
                {
                    mapCopy[x, y] = false;
                }
                    // Otherwise remain
                else
                {
                    mapCopy[x, y] = map[x, y];
                }
            }
        }

        // The new copy is now the current map
        return mapCopy;
    }

    // For the given cell position, count the number of neighboring cells that are filled
    private int CountFilledNeighbors(int x, int y, bool[,] map)
    {
        int count = 0;
        var neighbors = GetNeighbors(x, y, map);
        foreach (var neighbor in neighbors)
        {
            count += map[neighbor.x, neighbor.y] ? 1 : 0;  
        }
        return count;
    }

    // Get either the filled or empty regions on the map
    private List<List<Vector2Int>> GetRegions(bool[,] map, bool cellType)
    {
        var regions = new List<List<Vector2Int>>();
        bool[,] visited = new bool[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map[x, y] != cellType || visited[x, y]) continue;
                
                var region = GetRegionCells(x, y, map);
                regions.Add(region);
                // Mark all cells in the region as visited
                foreach (var cell in region)
                {
                    visited[cell.x, cell.y] = true;
                }
            }
        }

        return regions;
    }

    // Use flood fill logic to get the coordinates of all cells connected to the given cell,
    // i.e. part of the same "region"
    private List<Vector2Int> GetRegionCells(int startX, int startY, bool[,] map)
    {
        // If the given cell is filled, find all connected filled cells
        // If the given cell is empty, find all connected empty cells
        bool cellType = map[startX, startY];
        
        var regionCells = new List<Vector2Int>(); // Maintain list of visited cells
        var queue = new Queue<Vector2Int>(); // Queue of cells to explore
        queue.Enqueue(new Vector2Int(startX, startY)); // Add start cell to queue

        bool[,] visited = new bool[width, height]; // Track which cells have already been visited   
        visited[startX, startY] = true;

        while (queue.Count != 0)
        {
            var cell = queue.Dequeue();
            regionCells.Add(cell); // Add current cell to region

            var neighbors = GetNeighbors(cell.x, cell.y, map, true);
            foreach (var neighbor in neighbors)
            {
                if (InBounds(neighbor, map) && !visited[neighbor.x, neighbor.y] && map[neighbor.x, neighbor.y] == cellType)
                {
                    queue.Enqueue(neighbor);
                    visited[neighbor.x, neighbor.y] = true;
                }
            }
        }

        return regionCells;
    }

    // Get neighboring cells in either 8-directions or only the 4 orthogonal directions
    // Does not check if neighbor is within map boundaries
    private List<Vector2Int> GetNeighbors(int x, int y, bool[,] map, bool orthogonal = false)
    {
        List<Vector2Int> neighbors = new();
        
        Vector2Int[] directions = orthogonal ? orthogonalDirections : this.directions;

        foreach (var dir in directions) 
        {
            Vector2Int neighbor = new(x + dir.x, y + dir.y);
            if (InBounds(neighbor, map))
            {
                neighbors.Add(neighbor);        
            }
        }

        return neighbors;
    }

    private bool InBounds(Vector2Int cell, bool[,] map)
    {
        return cell.x >= 0 && cell.y >= 0 && cell.x < map.GetLength(0) && cell.y < map.GetLength(1);
    }
}
