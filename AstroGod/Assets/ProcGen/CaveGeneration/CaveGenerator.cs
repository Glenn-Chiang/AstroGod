using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CaveGenerator : MapGenerator
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

    public override void Generate()
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
}