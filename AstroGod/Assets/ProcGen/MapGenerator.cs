using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int width; // Number of tile columns
    [SerializeField] private int height; // Number of tile rows

    [SerializeField, Range(0, 100)]
    private int density; // Percentage of map that are walls
    [SerializeField] private int smoothSteps;

    [SerializeField] private string seed;
    [SerializeField] private bool useRandomSeed;

    public bool autoUpdate = false;
    
    [SerializeField] private MapDisplay mapDisplay;

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
                    map[x, y] = rng.Next(0, 100) < density;
                }
            }
        }

        // Repeatedly smooth the map
        for (int i = 0; i < smoothSteps; i++)
        {
            map = SmoothMap(map);
        }

        var emptyRegions = GetEmptyRegions(map);
        Debug.Log(emptyRegions.Count);

        return map;
    }

    // Smooth the map by giving neighbors a higher tendency to be the same
    private bool[,] SmoothMap(bool[,] map)
    {
        int filledNeighborThreshold = 4;

        // Create a new map so that we can read from the current map and write to the new map
        bool[,] mapCopy = new bool[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
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
                    // Otherwise remain
                }
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
    // The neighbors of a cell are the 8 (or fewer) cells surrounding it
    private int CountFilledNeighbors(int x, int y, bool[,] map)
    {
        int count = 0;
        for (int neighborX = x - 1; neighborX <= x + 1; neighborX++)
        {
            for (int neighborY = y - 1; neighborY <= y + 1; neighborY++)
            {
                // Skip current cell
                if (neighborX == x && neighborY == y) continue;

                if (InBounds(neighborX, neighborY, map))
                {
                    // Add to count if neighbor is filled
                    count += map[neighborX, neighborY] ? 1 : 0;
                }
                else
                {
                    // Count the area around the boundaries as filled cells
                    count++;
                }
            }
        }
        return count;
    }

    private List<HashSet<Vector2Int>> GetEmptyRegions(bool[,] map)
    {
        var regions = new List<HashSet<Vector2Int>>();
        var visitedCells = new HashSet<Vector2Int>();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Skip filled cells and cells that have already been visited
                if (map[x, y] || visitedCells.Contains(new Vector2Int(x, y))) continue;
                
                var region = GetRegionCells(x, y, map);
                regions.Add(region);
                // Add all cells in this region to the visited set
                visitedCells.UnionWith(region);
            }
        }

        return regions;
    }

    // Use flood fill logic to get the coordinates of all cells connected to the given cell,
    // i.e. part of the same "region"
    private HashSet<Vector2Int> GetRegionCells(int startX, int startY, bool[,] map)
    {
        // If the given cell is filled, find all connected filled cells
        // If the given cell is empty, find all connected empty cells
        bool cellType = map[startX, startY];
        
        var regionCells = new HashSet<Vector2Int>(); // Maintain set of visited cells
        var queue = new Queue<Vector2Int>(); // Queue of cells to explore
        queue.Enqueue(new Vector2Int(startX, startY)); // Add start cell to queue

        bool[,] visited = new bool[width, height]; // Track which cells have already been visited   

        while (queue.Count != 0)
        {
            var cell = queue.Dequeue();
            regionCells.Add(cell); // Add current cell to region

            for (int neighborX = cell.x - 1; neighborX <= cell.x + 1; neighborX++)
            {
                for (int neighborY = cell.y - 1; neighborY <= cell.y + 1; neighborY++)
                {
                    // Skip current cell
                    if (neighborX == cell.x && neighborY == cell.y) continue;

                    Vector2Int neighbor = new(neighborX, neighborY);
                    
                    if (InBounds(neighborX, neighborY, map) && !visited[neighborX, neighborY] 
                        && map[neighborX, neighborY] == cellType)
                    {
                        queue.Enqueue(neighbor);
                        visited[neighborX, neighborY] = true;
                    }
                }
            }
        }

        return regionCells;
    }

    private bool InBounds(int x, int y, bool[,] map)
    {
        return x >= 0 && y >= 0 && x < map.GetLength(0) && y < map.GetLength(1);
    }
}
