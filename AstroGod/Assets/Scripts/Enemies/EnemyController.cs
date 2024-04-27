using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    private EnemyStats stats;
    
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private EnemyMovement movement;

    public static event EventHandler<EnemyDeathEventArgs> OnEnemyDeath;

    private void Awake()
    {
        stats = new(data); // Initialize stats with base values

        healthManager.Initialize(stats.maxHealth);
        healthManager.OnDeath += HandleDeath;

        movement.Initialize(stats.moveSpeed);
    }

    private void HandleDeath(object sender, EventArgs e)
    {
        OnEnemyDeath?.Invoke(sender, new EnemyDeathEventArgs(data) );
        Destroy(gameObject);
    }
}

