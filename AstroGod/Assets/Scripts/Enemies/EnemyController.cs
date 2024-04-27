using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    private EnemyStats stats;
    [SerializeField] private HealthManager healthManager;

    public static event EventHandler<EnemyDeathEventArgs> OnEnemyDeath;

    private void Awake()
    {
        stats = new EnemyStats(data);
        
        healthManager.SetMaxHealth(stats.maxHealth.Value);
        healthManager.OnDeath += HandleDeath;
    }

    private void HandleDeath(object sender, EventArgs e)
    {
        OnEnemyDeath?.Invoke(sender, new EnemyDeathEventArgs(data) );
        Destroy(gameObject);
    }
}

