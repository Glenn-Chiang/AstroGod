using UnityEngine;

public class PointSpawner : Spawner
{
    protected override Vector2 GetSpawnPosition()
    {
        return transform.position;              
    }
}