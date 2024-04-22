using System;
using UnityEngine;
public class HealthManager : Damageable
{
    public float MaxHealth { get; private set; }
    public float Health { get; private set; }
    protected override float HitPoints { get => Health; set { Health = value; } }

    public HealthManager(float maxHealth)
    {
        MaxHealth = maxHealth;
        Health = MaxHealth;
    }

    public void Heal(float _health)
    {
        Health += Math.Min(_health, MaxHealth - Health); // prevent overhealing
    }
}