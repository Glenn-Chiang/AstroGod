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

    public void SpawnRandomEntity()
    {
        var spawnPosition = GetSpawnPosition();
        var entity = GetRandomEntity();
        Instantiate(entity, spawnPosition, Quaternion.identity);
    }

    private GameObject GetRandomEntity()
    {
        return RandomUtils.WeightedRandomSelect(entities);
    }

    protected abstract Vector2 GetSpawnPosition();
}