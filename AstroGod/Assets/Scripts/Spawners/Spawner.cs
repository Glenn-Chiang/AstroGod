using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private List<WeightedElement<GameObject>> entities;
    
    public void SpawnRandomEntities(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnRandomEntity();
        }
    }

    public void SpawnEntity(GameObject entity)
    {
        var spawnPosition = GetSpawnPosition();
        Instantiate(entity, spawnPosition, Quaternion.identity);
    }

    public void SpawnRandomEntityFromPool(EntityPool pool)
    {
        var spawnPosition = GetSpawnPosition();
        var entity = RandomUtils.WeightedRandomSelect(pool.Entities);
        Instantiate(entity, spawnPosition, Quaternion.identity);
    }

    public void SpawnRandomEntity()
    {
        var spawnPosition = GetSpawnPosition();
        var entity = RandomUtils.WeightedRandomSelect(entities);
        Instantiate(entity, spawnPosition, Quaternion.identity);
    }

    protected abstract Vector2 GetSpawnPosition();
}