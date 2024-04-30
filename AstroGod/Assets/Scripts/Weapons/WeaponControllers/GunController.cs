using UnityEngine;

public class GunController : WeaponController
{
    [SerializeField] private GunData gunData;
    protected override WeaponData WeaponData => gunData;
    protected float FirePower => gunData.FirePower;

    protected override IWeapon CreateWeaponInstance()
    {
        return new Gun(gunData);
    }

    protected override void Fire()
    {
        // If ammoManager is null, we will treat the weapon as having no ammo cost / infinite ammo
        if (ammoManager != null && !ammoManager.ConsumeAmmo(gunData.AmmoCost))
        {
            Debug.Log("Insufficient ammo");
            return;
        }
        Shoot();
    }

    // Shoot a single projectile
    protected void Shoot()
    {
        var projectile = Instantiate(gunData.ProjectilePrefab, firePoint.position, firePoint.rotation);
        var projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(FirePower * firePoint.right, ForceMode2D.Impulse);
        projectile.damage = Damage;

    }
}