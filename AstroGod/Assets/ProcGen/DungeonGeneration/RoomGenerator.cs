using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Generates the contents of a room within the dungeon
public class RoomGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;

    [SerializeField] private int numEnemies;
    // List of enemies that could possibly spawn in the room, along with their spawn rates
    [SerializeField] private List<WeightedElement<GameObject>> enemyPool;

    [SerializeField] private int numChests;
    // List of chest types that could spawn in the room, along with their spawn rates
    [SerializeField] private List<WeightedElement<GameObject>> chestPool;

    // Generate a room given a list of cells that make up the room
    public void GenerateRoomContent(List<Vector2Int> roomCells)
    {
        SpawnEntities(enemyPool, numEnemies, roomCells);
        SpawnEntities(chestPool, numChests, roomCells);
    }

    private void SpawnEntities(List<WeightedElement<GameObject>> entityPool, int count, List<Vector2Int> roomCells)
    {
        for (int i = 0; i < count; i++)
        {
            var entityToSpawn = RandomUtils.WeightedRandomSelect(entityPool);
            var spawnCell = RandomUtils.RandomSelect(roomCells);
            var spawnPos = tilemap.CellToWorld(new Vector3Int(spawnCell.x, spawnCell.y));
            Instantiate(entityToSpawn, spawnPos, Quaternion.identity);
        }          
    }

}