using System;
using UnityEngine;

public class HealthManager : ResourceManager, IDamageable
{
    private ICharacter character;

    public float MaxHealth => character.Stats.maxHealth.Value;
    public float Health { get; private set; }
    public override float MaxValue => MaxHealth;
    public override float Value => Health;

    float IDamageable.HitPoints => Health;

    public event EventHandler OnDeath;

    [SerializeField] private bool invincible = false;

    private void Start()
    {
        character = GetComponent<ICharacter>();
        Health = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (invincible) return;

        if (damage < Health)
        {
            Health -= damage;
        }
        else
        {
            Health = 0;
            Die();
        }
    }

    public void Heal(float _health)
    {
        Health += Math.Min(_health, MaxHealth - Health); // prevent overhealing
    }

    public void HealToFull()
    {
        Health = MaxHealth;
    }

    private void Die()
    {
        OnDeath?.Invoke(this, EventArgs.Empty);
    }
    void IDamageable.OnDestroyed() => Die();
}