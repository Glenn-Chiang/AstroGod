using System;
using UnityEngine;

public class XPManager : ResourceManager
{    
    public readonly float xpPerLevel = 100;
    private float totalXp = 0;
    public int Level => (int) (totalXp / xpPerLevel);
    public float CurrentLevelXp => totalXp % xpPerLevel; // XP earned at current level

    public override float MaxValue => xpPerLevel;
    public override float Value => CurrentLevelXp;

    public event EventHandler<LevelUpEventArgs> OnLevelUp;

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
        OnLevelUp?.Invoke(this, new LevelUpEventArgs(Level));
    }
}

public class LevelUpEventArgs
{
    public readonly int level;
    public LevelUpEventArgs(int _level)
    {
        level = _level;
    }
}