using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private EntityPool easyPool;
    [SerializeField] private EntityPool mediumPool;
    [SerializeField] private EntityPool hardPool;

    [SerializeField] private List<PointSpawner> spawners;
    [SerializeField] private float initialSpawnDelay;
    [SerializeField] private float spawnInterval;
    private float spawnTimer;

    private void Awake()
    {
        spawnTimer = initialSpawnDelay;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            foreach (var spawner in spawners)
            {
                spawner.SpawnRandomEntity();
            }
            spawnTimer = spawnInterval;
        }
    }
}