using UnityEngine;

public class WeaponPickUp : ItemPickUp
{
    public WeaponData weaponData;
    public WeaponInstance weaponInstance;

    public override ItemData ItemData => weaponData;
    public override ItemInstance ItemInstance { get => weaponInstance; set { weaponInstance = (WeaponInstance)value; } }

    private void Start()
    {
        weaponInstance = new(weaponData);
    }
}