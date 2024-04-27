using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    
    [SerializeField] private HealthManager healthManager;

    public static event EventHandler<EnemyDeathEventArgs> OnEnemyDeath;

    private void Awake()
    {
        healthManager.SetMaxHealth(data.MaxHealth);
        healthManager.OnDeath += HandleDeath;
    }

    private void HandleDeath(object sender, EventArgs e)
    {
        OnEnemyDeath?.Invoke(sender, new EnemyDeathEventArgs(data) );
        Destroy(gameObject);
    }
}

