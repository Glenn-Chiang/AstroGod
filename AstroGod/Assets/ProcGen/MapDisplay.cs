using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;

    [SerializeField] private TileBase floorTile;
    [SerializeField] private TileBase wallTile;

   public void DisplayMap(bool[,] map)
    {
        for (int x = 0;  x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                var pos = new Vector3Int(x, y, 0);
                if (map[x, y])
                {
                    tilemap.SetTile(pos, wallTile);
                } else
                {
                    tilemap.SetTile(pos, floorTile);
                }
            }
        }
    }
}
