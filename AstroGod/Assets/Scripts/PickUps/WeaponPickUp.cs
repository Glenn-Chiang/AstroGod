using UnityEngine;

public class WeaponPickUp : InstancedItemPickUp
{
    [SerializeField] WeaponData data;
    public override ItemData ItemData => data;

    protected override IItemInstance CreateInstance()
    {
        return new Weapon(data);
    }
}