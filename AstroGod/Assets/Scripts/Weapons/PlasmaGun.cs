using UnityEngine;

public class PlasmaGun : Weapon
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireForce = 25f;

    public override void Fire()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(fireForce * firePoint.right, ForceMode2D.Impulse);
    }
}