using UnityEngine;

public class ArmorPickUp : ItemInstancePickUp
{
    [SerializeField] private ArmorData data;
    protected override IItemInstance CreateItem()
    {
        return new Armor(data);
    }
}