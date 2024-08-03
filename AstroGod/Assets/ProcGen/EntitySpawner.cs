using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Spawns enemies and chests within an area
public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;

    [SerializeField] private int numEnemies;
    // List of enemies that could possibly spawn, along with their spawn rates
    [SerializeField] private List<WeightedElement<GameObject>> enemyPool;

    [SerializeField] private int numChests;
    // List of chest types that could spawn, along with their spawn rates
    [SerializeField] private List<WeightedElement<GameObject>> chestPool;

    // Generate entities within the given area
    // areaCells is the list of cells that make up the area
    public void Spawn(List<Vector2Int> areaCells)
    {
        SpawnEntities(enemyPool, numEnemies, areaCells);
        SpawnEntities(chestPool, numChests, areaCells);
    }

    private void SpawnEntities(List<WeightedElement<GameObject>> entityPool, int count, List<Vector2Int> roomCells)
    {
        for (int i = 0; i < count; i++)
        {
            var entityToSpawn = RandomUtils.WeightedRandomSelect(entityPool);
            var spawnCell = RandomUtils.RandomSelect(roomCells);
            var spawnPos = tilemap.CellToWorld(new Vector3Int(spawnCell.x, spawnCell.y)) + new Vector3(tilemap.cellSize.x / 2, tilemap.cellSize.y / 2);
            Instantiate(entityToSpawn, spawnPos, Quaternion.identity);
        }          
    }

}