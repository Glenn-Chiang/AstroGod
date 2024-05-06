using System;
using UnityEngine;

public class EnemyController : MonoBehaviour, ICharacter
{
    [SerializeField] private EnemyData data;
    CharacterData ICharacter.Data => data;
    private EnemyStats stats;
    CharacterStats ICharacter.Stats => stats;
    
    [SerializeField] private HealthManager healthManager;
    public static event EventHandler<EnemyDeathEventArgs> OnEnemyDeath;
    [SerializeField] private XpDropper xpDropper;

    private void Awake()
    {
        stats = new(data); // Initialize stats with base values

        healthManager.OnDeath += HandleDeath;
    }

    private void HandleDeath(object sender, EventArgs e)
    {
        OnEnemyDeath?.Invoke(sender, new EnemyDeathEventArgs(data) );
        Destroy(gameObject);

        xpDropper.DropXP(data.XpReward);
    }
}

