using System.Collections.Generic;
using UnityEngine;

public class RandomWalkVisualizer : MonoBehaviour
{
    private int maxTiles = 8;
    [SerializeField] private int cellsPerRow = 4;
    [SerializeField] private int cellsPerCol = 4;
    [SerializeField] private float gap = 2;
    private Vector3 origin;
    [SerializeField] private GameObject tilePrefab;
    private Vector3 TileSize => tilePrefab.GetComponent<Renderer>().bounds.size;
    private GameObject[,] tiles;

    private void Awake()
    {
        origin = transform.position;
        tiles = new GameObject[cellsPerRow, cellsPerCol];
        InitializeGrid();
        GenerateWalk();
    }

    private void InitializeGrid()
    {
        for (int row = 0; row < cellsPerRow; row++)
        {
            for (int col = 0; col < cellsPerCol; col++)
            {
                var tileX = origin.x + col * (TileSize.x + gap);
                var tileY = origin.y - row * (TileSize.y + gap);
                var tilePosition = new Vector2(tileX, tileY);
                var tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity);
                tiles[row, col] = tile;
            }
        }
    }

    private void GenerateWalk()
    {
        var randomWalker = new RandomWalker(cellsPerRow, cellsPerCol, maxTiles);
        randomWalker.Walk();
        var grid = randomWalker.grid;

        for (int row = 0; row < cellsPerRow; row++)
        {
            for (int col = 0; col < cellsPerCol; col++)
            {
                var cell = grid[row, col];
                var tile = tiles[row, col];
                var tileSprite = tile.GetComponent<SpriteRenderer>();
                if (cell)
                {
                    tileSprite.color = Color.white;
                } else
                {
                    tileSprite.color = Color.black;    
                }
            }
        }
    }
}