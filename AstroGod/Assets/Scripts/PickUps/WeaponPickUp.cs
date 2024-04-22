using UnityEngine;

public class WeaponPickUp : InstancedItemPickUp
{
    [SerializeField] WeaponData data;
    protected override ItemData ItemData => data;

    protected override IItem CreateInstance()
    {
        return new Weapon(data);
    }
}