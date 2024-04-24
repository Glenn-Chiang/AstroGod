using UnityEngine;

public class WeaponPickUp : ItemPickUp
{
    [SerializeField] private WeaponData data;
    protected override ItemData ItemData => data; 
    protected override IItem CreateItem()
    {
        return new Weapon(data);
    }
}