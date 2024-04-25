using UnityEngine;

public class WeaponPickUp : ItemInstancePickUp
{
    [SerializeField] private WeaponData data;

    protected override ItemInstance CreateItem()
    {
        return new Weapon(data);
    }
}