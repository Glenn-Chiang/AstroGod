using System.Collections.Generic;
using UnityEngine;

public class RandomWalker
{
    private readonly int rowCount;
    private readonly int colCount;
    public readonly bool[,] grid;
    private readonly int maxCells;
    private readonly List<Vector2Int> directions = new List<Vector2Int>() { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
    private readonly HashSet<Vector2Int> visited = new();

    public RandomWalker(int rowCount, int colCount, int maxCells)
    {
        this.rowCount = rowCount;
        this.colCount = colCount;
        this.maxCells = maxCells;
        grid = new bool[rowCount, colCount];
    }

    public void Walk()
    {
        var currentCell = RandomCell();

        while (visited.Count < maxCells)
        {
            grid[currentCell.x, currentCell.y] = true;
            visited.Add(currentCell);

            var nextCell = currentCell + RandomDirection();
            
            if (nextCell.x >= 0 && nextCell.x < rowCount && nextCell.y >= 0 && nextCell.y < colCount)
            {
                currentCell = nextCell;
            }
        }

    }

    private Vector2Int RandomCell()
    {
        var random = new System.Random();
        int row = random.Next(rowCount);
        int col = random.Next(colCount);
        return new Vector2Int (row, col);
    }

    private Vector2Int RandomDirection()
    {
        return RandomUtils.RandomSelect(directions);
    }
}