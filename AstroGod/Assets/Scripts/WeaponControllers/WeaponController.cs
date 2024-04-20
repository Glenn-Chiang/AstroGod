using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    
    public Weapon weaponInstance;
    private float Damage => weaponInstance.Damage;
    private float FireRate => weaponInstance.FireRate;
    private float FirePower => weaponInstance.Data.FirePower;

    private PlayerMovement player;
 

    private void Start()
    {
        player = PlayerController.Instance.Movement;
    }

    public void Fire()
    {
        var projectile = Instantiate(weaponInstance.Data.ProjectilePrefab, firePoint.position, firePoint.rotation);
        var projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(FirePower * firePoint.right, ForceMode2D.Impulse);
        projectile.damage = Damage;
    }
}