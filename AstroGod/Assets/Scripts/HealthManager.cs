using System;
using UnityEngine;
public abstract class HealthManager : Damageable
{
    [field: SerializeField] private float MaxHealth { get; }
    [SerializeField] private float health;
    public override float HitPoints { get => health; protected set { health = value; } }

    public HealthManager()
    {
        health = MaxHealth;
    }

    public void Heal(float _health)
    {
        health += Math.Min(_health, MaxHealth - health); // prevent overhealing
    }
}