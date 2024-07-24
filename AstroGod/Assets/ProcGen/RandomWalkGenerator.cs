using UnityEngine;

public class RandomWalkGenerator: MapGenerator
{
    protected override bool[,] GenerateMap(System.Random rng)
    {
        bool[,] map = new bool[width, height];

        // Completely fill the grid
        for (int x= 0; x < width; x++)
        {
            for (int y= 0; y < height; y++)
            {
                map[x, y] = true;
            }
        }

        int emptyPercent = 100 - fillPercent;
        int emptyLimit = (int) (emptyPercent / 100f * width * height); // Max number of empty cells
        int emptyCount = 0;

        // Pick a start position and clear it
        int currentX = rng.Next(0, width);
        int currentY = rng.Next(0, height);
        map[currentX, currentY] = false;

        while (emptyCount < emptyLimit)
        {
            // Pick a random direction to walk: up, down, right or left
            var dir = RandomUtils.RandomSelect(orthogonalDirections, rng);
            int nextX = currentX + dir.x;
            int nextY = currentY + dir.y;

            // Retry if next cell is not in bounds
            if (!InBounds(nextX, nextY, map)) continue;

            // If the next cell is filled, clear it and update number of empty cells
            if (map[nextX, nextY])
            {
                map[nextX, nextY] = false;
                emptyCount++;
            }

            // "Walk" to the next cell
            currentX = nextX;
            currentY = nextY;
        }

        // Fill the borders
        for (int x = 0; x < width; x++)
        {
            map[x, 0] = true;
            map[x, height - 1] = true;
        }
        for (int y = 0; y < height; y++)
        {
            map[0, y] = true;
            map[width - 1, y] = true;
        }

        // Repeatedly smooth the map
        for (int i = 0; i < smoothSteps; i++)
        {
            map = SmoothMap(map);
        }

        return map;
    }
}