using UnityEngine;

[CreateAssetMenu(fileName = "ArmorData", menuName = "Item/Armor")]
public class ArmorData : ItemData
{
    public override ItemType ItemType => ItemType.Armor;
    [field: SerializeField] public float BaseResistance { get; }
}