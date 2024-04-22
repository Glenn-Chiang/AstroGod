using System;
using UnityEngine;
public abstract class HealthManager : Damageable
{
    [field: SerializeField] public float MaxHealth { get; private set; }
    [SerializeField] private float health;
    public override float HitPoints { get => health; protected set { health = value; } }

    private void Awake()
    {
        health = MaxHealth;
    }

    public void Heal(float _health)
    {
        health += Math.Min(_health, MaxHealth - health); // prevent overhealing
    }
}