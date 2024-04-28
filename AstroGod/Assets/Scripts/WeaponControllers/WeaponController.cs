using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    [SerializeField] protected Transform firePoint;
    
    public Weapon weaponInstance;
    protected float Damage => weaponInstance.Damage;
    private float FireRate => weaponInstance.FireRate;
    protected float FirePower => weaponInstance.Data.FirePower;
    private int AmmoCost => weaponInstance.Data.AmmoCost;

    public AmmoManager ammoManager;

    private bool canFire = true;

    public void HandleFire()
    {
        if (!canFire) return;
        
        // If ammoManager is null, we will treat the weapon as having no ammo cost / infinite ammo
        if (ammoManager != null && !ammoManager.ConsumeAmmo(AmmoCost))
        {
            Debug.Log("Insufficient ammo");
            return;
        }

        Fire();
        StartCoroutine(CoolDown());
    }

    protected abstract void Fire();

    private IEnumerator CoolDown()
    {
        canFire = false;
        yield return new WaitForSeconds(FireRate);
        canFire = true;
    }
}