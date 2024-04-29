using UnityEngine;

public class ContinuousSpawner : Spawner
{
    [SerializeField] private float spawnInterval;
    private float spawnTimer;
    [SerializeField] private int spawnCount;

    private void Start()
    {
        spawnTimer = initialSpawnDelay;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0 )
        {
            SpawnRandomEntities(spawnCount);
            spawnTimer = spawnInterval;
        }
    }
}