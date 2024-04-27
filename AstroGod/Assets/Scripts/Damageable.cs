using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    protected abstract float HitPoints { get; set; }
    public virtual void TakeDamage(float damage)
    {
        if (damage < HitPoints)
        {
            HitPoints -= damage;
        }
        else
        {
            HitPoints = 0;
            OnDestroyed();
        }
    }

    protected abstract void OnDestroyed();
}