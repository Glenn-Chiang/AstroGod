using UnityEngine;

public class GunController : WeaponController
{
    [SerializeField] protected Transform firePoint;

    [SerializeField] private GunData weaponData;
    protected override WeaponData WeaponData => weaponData;

    protected override void Fire()
    {
        // If ammoManager is null, we will treat the weapon as having no ammo cost / infinite ammo
        if (ammoManager != null && !ammoManager.ConsumeAmmo(weaponData.AmmoCost))
        {
            Debug.Log("Insufficient ammo");
            return;
        }
        Shoot();
    }

    // Shoot a single projectile
    protected void Shoot()
    {
        var projectile = Instantiate(weaponData.ProjectilePrefab, firePoint.position, firePoint.rotation);
        var projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(weaponData.FirePower * firePoint.right, ForceMode2D.Impulse);
        projectile.damage = Damage;

    }
}