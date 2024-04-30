using UnityEngine;

public class MeleeWeaponController : WeaponController
{
    [SerializeField] private MeleeWeaponData weaponData;
    protected override WeaponData WeaponData => weaponData;

    protected override IWeapon CreateWeaponInstance()
    {
        return new MeleeWeapon(weaponData);
    }

    protected override void Fire()
    {
        Debug.Log("Melee attack");
    }
}