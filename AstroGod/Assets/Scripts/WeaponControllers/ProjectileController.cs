using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the projectile collides with a damagaeable object, deal damage to it
        if (collision.collider.TryGetComponent<Damageable>(out var damageableObject))
        {
            damageableObject.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}