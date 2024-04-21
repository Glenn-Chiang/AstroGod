public abstract class Damageable
{
    public abstract float HitPoints { get; protected set; }
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