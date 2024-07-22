using System;
using UnityEngine;

public class CellularAutomaton
{
    private readonly int width;
    private readonly int height;
    private bool[,] map;
    private int filledNeighborThreshold = 4;

    public CellularAutomaton(int width, int height)
    {
        this.width = width;
        this.height = height;
        map = new bool[width, height];
    }

    public bool[,] GenerateMap(int density, int smoothSteps, System.Random rng)
    {
        // Density is the approximate percentage of the map that will be filled
        density = Mathf.Clamp(density, 0, 100);

        // Initialize map with random boolean values based on density percentage
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Map boundaries are always filled
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    map[x, y] = true;
                } else
                {
                    map[x, y] = rng.Next(0, 100) < density;
                }
            }
        }

        for (int i = 0; i < smoothSteps; i++)
        {
            SmoothMap();
        }

        return map;
    }

    private void SmoothMap()
    {
        // Create a new map so that we can read from the current map and write to the new map
        bool[,] mapCopy = new bool[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // If the cell has more than "neighborThreshold" filled neighbors,
                // then fill the cell
                int filledNeighbors = CountFilledNeighbors(x, y);
                if (filledNeighbors > filledNeighborThreshold)
                {
                    mapCopy[x, y] = true;
                // If the cell has less than "neighborThreshold" filled neighbors,
                // then clear the cell
                } else if (filledNeighbors < filledNeighborThreshold)
                {
                    mapCopy[x, y] = false;
                // Otherwise remain
                } else
                {
                    mapCopy[x, y] = map[x, y];
                }
            }
        }

        // The new copy is now the current map
        map = mapCopy;
    }

    // For the given cell position, count the number of neighboring cells that are filled
    // The neighbors of a cell are the 8 (or fewer) c     ells surrounding it
    private int CountFilledNeighbors(int x, int y)
    {
        int count = 0;
        for (int neighborX = x - 1; neighborX <= x + 1; neighborX++)
        {
            for (int neighborY = y - 1; neighborY <= y + 1; neighborY++)
            {
                // Skip current cell
                if (neighborX == x && neighborY == y) continue;
                 
                if (InBounds(neighborX, neighborY))
                {
                    // Add to count if neighbor is filled
                    count += map[neighborX, neighborY] ? 1 : 0;
                } else
                {
                    // Count the area around the boundaries as filled cells
                    count++;
                }
            }
        }
        return count;
    }

    private bool InBounds(int x, int y)
    {
        return x >= 0 && y >= 0 && x < width && y < height;
    }
}