using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private List<PointSpawner> spawners;

    [SerializeField] private float spawnInterval;
    [SerializeField] private int spawnCount;
    private float spawnTimer;

    private void Awake()
    {
        spawnTimer = spawnInterval;

        foreach (var spawner in spawners)
        {
            spawner.SpawnRandomEntities(spawnCount);
        }
    }

    private void Update()
    {
        //spawnTimer -= Time.deltaTime;
        //if (spawnTimer <= 0 )
        //{
        //    foreach ( var spawner in spawners )
        //    {
        //        spawner.SpawnRandomEntities(spawnCount);
        //    }
        //    spawnTimer = spawnInterval;
        //}
    }
}