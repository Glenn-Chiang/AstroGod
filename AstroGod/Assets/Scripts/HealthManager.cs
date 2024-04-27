using System;
using UnityEngine;
public class HealthManager : Damageable
{
    private Stat maxHealthStat;
    public float MaxHealth => maxHealthStat.Value;
    public float Health { get; private set; }
    protected override float HitPoints { get => Health; set { Health = value; } }

    public event EventHandler OnDeath;

    public void Initialize(Stat _maxHealthStat)
    {
        maxHealthStat = _maxHealthStat;
        Health = MaxHealth;
    }

    public void Heal(float _health)
    {
        Health += Math.Min(_health, MaxHealth - Health); // prevent overhealing
    }

    protected override void OnDestroyed()
    {
        OnDeath?.Invoke(this, EventArgs.Empty);
    }
}