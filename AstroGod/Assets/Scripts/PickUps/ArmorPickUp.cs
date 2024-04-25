using UnityEngine;

public class ArmorPickUp : ItemInstancePickUp
{
    [SerializeField] private ArmorData data;
    protected override ItemInstance CreateItem()
    {
        return new Armor(data);
    }
}