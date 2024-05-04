using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Room room; // The room containing this spawner

    private float MinX => room.LeftBound;
    private float MaxX => room.RightBound;
    private float MinY => room.BottomBound;
    private float MaxY => room.TopBound;

    [SerializeField] private List<WeightedElement<GameObject>> entities;
    [SerializeField] protected float initialSpawnDelay;
    [SerializeField] private int initialSpawnCount;

    private void Awake()
    {
        StartCoroutine(TimeUtils.ExecuteAfterDelay(initialSpawnDelay, () => SpawnRandomEntities(initialSpawnCount)));
    }

    protected void SpawnRandomEntities(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnRandomEntity();
        }
    }

    protected void SpawnRandomEntity()
    {
        var spawnPosition = GetRandomPosition();
        var entityToSpawn = GetRandomEntity();
        Instantiate(entityToSpawn, spawnPosition, Quaternion.identity);
    }

    private GameObject GetRandomEntity()
    {
        return RandomUtils.WeightedRandomSelect(entities);
    }

    private Vector2 GetRandomPosition()
    {
        float xPos = UnityEngine.Random.Range(MinX, MaxX);
        float yPos = UnityEngine.Random.Range(MinY, MaxY);
        return new Vector2(xPos, yPos);
    }
}