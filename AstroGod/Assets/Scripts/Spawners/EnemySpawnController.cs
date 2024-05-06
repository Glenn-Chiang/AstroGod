using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private EntityPool easyPool;
    [SerializeField] private EntityPool mediumPool;
    [SerializeField] private EntityPool hardPool;

    private EntityPool currentPool;

    [SerializeField] private List<PointSpawner> spawners;
    [SerializeField] private float initialSpawnDelay;
    [SerializeField] private float spawnInterval;
    private float spawnTimer;

    private void Awake()
    {
        currentPool = easyPool;
        spawnTimer = initialSpawnDelay;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            foreach (var spawner in spawners)
            {
                spawner.SpawnRandomEntityFromPool(currentPool);
            }
            spawnTimer = spawnInterval;
        }
    }
}