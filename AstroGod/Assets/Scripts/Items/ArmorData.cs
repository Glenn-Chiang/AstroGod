using UnityEngine;

[CreateAssetMenu(fileName = "ArmorData", menuName = "Item/Armor")]
public class ArmorData : ItemData
{
    [field: SerializeField] public float BaseResistance { get; }
}