using UnityEngine;
using UnityEngine.UIElements;

public class RandomWalkGenerator: MapGenerator
{
    [SerializeField, Range(0, 100)] private int turn90Chance; // Chance for the walker to turn 90 or -90 degrees at each step
    [SerializeField, Range(0, 100)] private int turn180Chance; // Chance for the walker to turn 180 degrees at each step

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

        // Pick a random direction to start walking in
        Vector2Int dir = RandomUtils.RandomSelect(orthogonalDirections, rng);

        while (emptyCount < emptyLimit)
        {
            dir = ChangeDirection(dir, rng);

            int nextX = currentX + dir.x;
            int nextY = currentY + dir.y;

            // Retry if next cell is on or outside of the map boundary
            if (nextX <= 0 || nextY <= 0 || nextX >= width - 1 || nextY >= height - 1)
            {
                continue;
            }

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

        //Repeatedly smooth the map
        for (int i = 0; i < smoothSteps; i++)
        {
            map = SmoothMap(map);
        }

        return map;
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
               
                mapCopy[x, y] = filledNeighbors >= 4 && map[x, y];
            }
        }

        // The new copy is now the current map
        return mapCopy;
    }

    private Vector2Int ChangeDirection(Vector2Int dir, System.Random rng)
    {
        Vector2Int dir180 = new(-dir.x, -dir.y); // The direction that is a 180 degree turn from this direction
        Vector2Int dir90clockwise = new(dir.y, -dir.x); // The direction that is a 90 degrees turn from this direction
        Vector2Int dir90anticlockwise = new(-dir.y, dir.x); // The direction that is a -90 degrees turn from this direction

        int sameDirChance = 100 - turn180Chance - turn90Chance;
        
        WeightedElement<Vector2Int>[] dirChances = { 
            new (dir, sameDirChance),
            new (dir180, turn180Chance), 
            new (dir90anticlockwise, turn90Chance / 2),
            new (dir90clockwise, turn90Chance / 2)    
        };

        return RandomUtils.WeightedRandomSelect(dirChances, rng);
    }
}