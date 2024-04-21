using UnityEngine;

public class PlayerHealthManager : HealthManager
{
    protected override void OnDestroyed()
    {
        // Implement player death logic
        Debug.Log("Player died");
    }
}