using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [SerializeField] private List<GameObject> entities;
    [SerializeField] private int initialSpawnCount;

    private void Awake()
    {
        SpawnRandomEntities(initialSpawnCount);
    }

    private void SpawnRandomEntities(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnRandomEntity();
        }
    }

    private void SpawnRandomEntity()
    {
        var spawnPosition = GetRandomPosition();
        var entityToSpawn = GetRandomEntity();
        Instantiate(entityToSpawn, spawnPosition, Quaternion.identity);
    }

    private GameObject GetRandomEntity()
    {
        return RandomUtils.RandomSelect(entities);
    }

    private Vector2 GetRandomPosition()
    {
        float xPos = Random.Range(minX, maxX);
        float yPos = Random.Range(minY, maxY);
        return new Vector2(xPos, yPos);
    }
}