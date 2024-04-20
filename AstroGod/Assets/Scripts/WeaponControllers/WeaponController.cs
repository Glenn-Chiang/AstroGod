using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    
    public Weapon weaponInstance;
    private float Damage => weaponInstance.Damage;
    private float FireRate => weaponInstance.FireRate;
    private float FirePower => weaponInstance.Data.FirePower;

    private bool canFire = true;

    public void Fire()
    {
        if (!canFire) return;

        var projectile = Instantiate(weaponInstance.Data.ProjectilePrefab, firePoint.position, firePoint.rotation);
        var projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(FirePower * firePoint.right, ForceMode2D.Impulse);
        projectile.damage = Damage;

        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {
        canFire = false;
        yield return new WaitForSeconds(FireRate);
        canFire = true;
    }
}