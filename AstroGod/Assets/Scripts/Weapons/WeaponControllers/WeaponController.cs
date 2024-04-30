using System.Collections;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    protected abstract WeaponData WeaponData { get; }
    public IWeapon weaponInstance;
    protected float Damage => weaponInstance.Damage;
    private float FireRate => weaponInstance.FireRate;

    public AmmoManager ammoManager;

    private bool canFire = true;

    private void Awake()
    {
        CreateWeaponInstance();
    }

    protected abstract IWeapon CreateWeaponInstance();

    public void HandleFire()
    {
        if (!canFire) return;

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