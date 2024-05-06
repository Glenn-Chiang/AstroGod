using UnityEngine;

public class MeleeWeaponController : WeaponController
{
    [SerializeField] private Transform hitPoint;
    [SerializeField] private float hitRadius;
    [SerializeField] private LayerMask targetLayers;

    [SerializeField] private MeleeWeaponData weaponData;
    protected override WeaponData WeaponData => weaponData;

    protected override IWeapon CreateWeaponInstance()
    {
        return new MeleeWeapon(weaponData);
    }

    protected override void Fire()
    {
        var hitTargets = Physics2D.OverlapCircleAll(hitPoint.position, hitRadius, targetLayers);
        foreach (var target in hitTargets)
        {
            if (target.TryGetComponent<IDamageable>(out var damageableTarget))
            {
                damageableTarget.TakeDamage(Damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (hitPoint == null) return;
        Gizmos.DrawWireSphere(hitPoint.position, hitRadius);
    }
}

