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
        EnemyController.OnEnemyDeath += AddXP;
    }

    private void AddXP(object sender, EnemyDeathEventArgs e)
    {
        var xpReward = e.enemyData.XpReward;
        if (CurrentLevelXp + xpReward >= xpPerLevel)
        {
            LevelUp();
        }
        totalXp += xpReward;
    }

    private void LevelUp()
    {
        Debug.Log("Leveled up");
    }
}