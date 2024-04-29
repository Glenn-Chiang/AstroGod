using System;
using UnityEngine;

public class HealthManager : Damageable, IDepletable
{
    private ICharacter character;

    public float MaxHealth => character.Stats.maxHealth.Value;
    public float Health { get; private set; }
    float IDepletable.MaxValue => MaxHealth;
    float IDepletable.Value => Health;

    protected override float HitPoints { get => Health; set { Health = value; } }

    public event EventHandler OnDeath;

    private void Start()
    {
        character = GetComponent<ICharacter>();
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