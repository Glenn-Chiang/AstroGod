using UnityEngine;

public class ArmorPickUp : ItemPickUp
{
    [SerializeField] ArmorData data;
    protected override ItemData ItemData => data;

    protected override IItem CreateInstance()
    {
        return new Armor(data);
    }
}