using UnityEngine;

public class GunController : WeaponController
{
    protected override void Fire()
    {
        Shoot();
    }

    // Shoot a single projectile
    protected void Shoot()
    {
        var projectile = Instantiate(weaponInstance.Data.ProjectilePrefab, firePoint.position, firePoint.rotation);
        var projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(FirePower * firePoint.right, ForceMode2D.Impulse);
        projectile.damage = Damage;

    }
}