using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    private EnemyStats stats;
    [SerializeField] private HealthManager healthManager;

    private void Awake()
    {
        stats = new EnemyStats(enemyData);
        
        healthManager.SetMaxHealth(stats.maxHealth.Value);
        healthManager.OnDeath += HandleDeath;
    }

    private void HandleDeath(object sender, EventArgs e)
    {
        Debug.Log($"{enemyData.Name} died");
        Destroy(gameObject);
    }
}
