using UnityEngine;

[CreateAssetMenu(fileName = "ArmorData", menuName = "Item/Armor")]
public class ArmorData : ItemData
{
    public override ItemType ItemType => ItemType.Armor;
    public override bool Instantiable => true;
    [field: SerializeField] public float BaseResistance { get; }
}