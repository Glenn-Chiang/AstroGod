using UnityEngine;

public class MeleeWeaponPickUp : ItemInstancePickUp
{
    [SerializeField] private MeleeWeaponData data;

    protected override IItemInstance CreateItem()
    {
        return new MeleeWeapon(data);
    }
}