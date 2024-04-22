using System;
using UnityEngine;

public class PlayerStats
{
    public Stat MaxHealth { get; private set; }
    public Stat MaxAmmo { get; private set; }
    public Stat MoveSpeed { get; private set; }

    public PlayerStats(CharacterStats stats)
    {
        MaxHealth = new(stats.MaxHealth.BaseValue, stats.MaxHealth.MaxValue);
        MaxAmmo = new(stats.MaxAmmo.BaseValue, stats.MaxAmmo.MaxValue);
        MoveSpeed = new(stats.MoveSpeed.BaseValue, stats.MoveSpeed.MaxValue);
    }
}