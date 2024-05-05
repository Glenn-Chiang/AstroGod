using UnityEngine;

public class AreaSpawner : Spawner
{
    [SerializeField] private Room room; // The room containing this spawner

    private float MinX => room.LeftBound;
    private float MaxX => room.RightBound;
    private float MinY => room.BottomBound;
    private float MaxY => room.TopBound;

    protected override Vector2 GetSpawnPosition()
    {
        float xPos = Random.Range(MinX, MaxX);
        float yPos = Random.Range(MinY, MaxY);
        return new Vector2(xPos, yPos);
    }
}