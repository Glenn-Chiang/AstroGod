using UnityEngine;

public class WeaponPickUp : ItemPickUp
{
    public WeaponData weaponData;
    public WeaponInstance weaponInstance;

    public override ItemData ItemData => weaponData;
    public override ItemInstance ItemInstance { get => weaponInstance; set { weaponInstance = (WeaponInstance)value; } }

    private void Awake()
    {
        weaponInstance = new(weaponData);
    }

    protected override void PickUp()
    {
        if (Player.WeaponInventory.AddItem(weaponInstance))
        {
            // Destroy the pickup only if it was successfully added to the inventory
            Destroy(gameObject);
        }
    }
}