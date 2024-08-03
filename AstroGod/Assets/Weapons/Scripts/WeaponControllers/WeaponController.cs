using System.Collections;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    protected abstract WeaponData WeaponData { get; }
    protected float Damage => WeaponData.Damage;
    private float FireRate => WeaponData.FireRate;

    public AmmoManager ammoManager;

    private bool canFire = true;

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