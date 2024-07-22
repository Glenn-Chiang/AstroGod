using UnityEngine;

public abstract class WeaponData : ItemData
{
    public override ItemType ItemType => ItemType.Weapon;
    [field : SerializeField] public float BaseFireRate { get; private set; }
    [field : SerializeField] public float BaseDamage { get; private set; }

}
