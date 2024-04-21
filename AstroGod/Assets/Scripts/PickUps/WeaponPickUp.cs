using UnityEngine;

public class WeaponPickUp : ItemPickUp
{
    [SerializeField] WeaponData data;
    protected override ItemData ItemData => data;

    protected override IItem CreateItem()
    {
        return new Weapon(data);
    }
}