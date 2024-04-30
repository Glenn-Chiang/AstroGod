using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Item/Weapon")]
public class WeaponData : ItemData
{
    public override ItemType ItemType => ItemType.Weapon;
    [field : SerializeField] public float BaseFireRate { get; private set; }
    [field : SerializeField] public float BaseDamage { get; private set; }

}
