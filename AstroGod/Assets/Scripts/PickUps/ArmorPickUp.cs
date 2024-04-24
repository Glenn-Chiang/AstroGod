using UnityEngine;

public class ArmorPickUp : ItemPickUp
{
    [SerializeField] private ArmorData data;
    protected override ItemData ItemData => data;
    protected override IItem CreateItem()
    {
        return new Armor(data);
    }
}