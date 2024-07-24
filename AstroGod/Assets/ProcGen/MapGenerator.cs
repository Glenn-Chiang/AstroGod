using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapGenerator : MonoBehaviour
{
    [SerializeField] protected int width; // Number of tile columns
    [SerializeField] protected int height; // Number of tile rows
    [SerializeField, Range(0, 100)] protected int fillPercent;
    [SerializeField] protected int smoothSteps;

    [SerializeField] protected string seed;
    [SerializeField] protected bool useRandomSeed;

    public static readonly Vector2Int[] directions = { new(0, -1), new(0, 1), new(-1, 0), new(1, 0), new(-1, -1), new(-1, 1), new(1, -1), new Vector2Int(1, 1) };
    public static readonly Vector2Int[] orthogonalDirections = { new(0, -1), new(0, 1), new(-1, 0), new(1, 0) };

    [SerializeField] private MapDisplay mapDisplay;

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }
        System.Random rng = new(seed.GetHashCode());
        var map = GenerateMap(rng);
        mapDisplay.DisplayMap(map);
    }

    protected abstract bool[,] GenerateMap(System.Random rng);

    protected bool InBounds(Vector2Int cell, bool[,] map)
    {
        return InBounds(cell.x, cell.y, map);
    }
    protected bool InBounds(int x, int y, bool[,] map)
    {
        return x >= 0 && y >= 0 && x < map.GetLength(0) && y < map.GetLength(1);
    }

    // Get neighboring cells in either 8-directions or only the 4 orthogonal directions
    // Does not check if neighbor is within map boundaries
    protected List<Vector2Int> GetNeighbors(int x, int y, bool[,] map, bool orthogonal = false)
    {
        List<Vector2Int> neighbors = new();

        Vector2Int[] dirs = orthogonal ? orthogonalDirections : directions;

        foreach (var dir in dirs)
        {
            Vector2Int neighbor = new(x + dir.x, y + dir.y);
            if (InBounds(neighbor, map))
            {
                neighbors.Add(neighbor);
            }
        }

        return neighbors;
    }

    // For the given cell position, count the number of neighboring cells that are filled
    protected int CountFilledNeighbors(int x, int y, bool[,] map)
    {
        int count = 0;
        var neighbors = GetNeighbors(x, y, map);
        foreach (var neighbor in neighbors)
        {
            count += map[neighbor.x, neighbor.y] ? 1 : 0;
        }
        return count;
    }

    // Smooth the map by giving neighbors a higher tendency to be the same
    protected bool[,] SmoothMap(bool[,] map)
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
                if (filledNeighbors > 4)
                {
                    mapCopy[x, y] = true;
                    // If the cell has less than "neighborThreshold" filled neighbors,
                    // then clear the cell
                }
                else if (filledNeighbors < 4)
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
}