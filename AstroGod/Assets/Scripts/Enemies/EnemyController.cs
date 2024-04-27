using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    private EnemyStats stats;
    [SerializeField] private HealthManager healthManager;

    private void Awake()
    {
        stats = new EnemyStats(enemyData);
        Debug.Log(stats.maxHealth.Value);
        healthManager.SetMaxHealth(stats.maxHealth.Value);
    }
}
