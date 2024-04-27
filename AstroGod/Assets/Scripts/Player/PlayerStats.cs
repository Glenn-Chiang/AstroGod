using System;
using UnityEngine;

public class PlayerStats
{
    public readonly Stat maxHealth;
    public readonly Stat maxAmmo;
    public readonly Stat moveSpeed;

    public PlayerStats(PlayerCharacterData stats)
    {
        maxHealth = new(stats.MaxHealth.BaseValue, stats.MaxHealth.MaxValue);
        maxAmmo = new(stats.MaxAmmo.BaseValue, stats.MaxAmmo.MaxValue);
        moveSpeed = new(stats.MoveSpeed.BaseValue, stats.MoveSpeed.MaxValue);
    }
}