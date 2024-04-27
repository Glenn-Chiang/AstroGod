using System;
using UnityEngine;

public class XPManager : MonoBehaviour
{    
    public readonly float xpPerLevel = 10;
    [SerializeField] private float totalXp = 0;
    public int Level => (int) (totalXp / xpPerLevel);
    public float CurrentLevelXp => totalXp % xpPerLevel; // XP earned at current level

    private void Start()
    {
        EnemyController.OnEnemyDeath += HandleEnemyDeath;
    }

    private void AddXp(float xpReward)
    {
        if (CurrentLevelXp + xpReward >= xpPerLevel)
        {
            LevelUp();
        }
        totalXp += xpReward;
    }

    private void HandleEnemyDeath(object sender, EnemyDeathEventArgs e)
    {
        AddXp(e.enemyData.XpReward);
    }

    private void LevelUp()
    {
        Debug.Log("Leveled up");
    }
}