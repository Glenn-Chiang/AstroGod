using UnityEngine;

public class ArmorPickUp : ItemPickUp
{
    [SerializeField] ArmorData data;
    protected override ItemData ItemData => data;

    protected override IItem CreateItem()
    {
        return new Armor(data);
    }
}