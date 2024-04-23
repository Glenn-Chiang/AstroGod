using UnityEngine;

public class ArmorPickUp : InstancedItemPickUp
{
    [SerializeField] ArmorData data;
    public override ItemData ItemData => data;

    protected override IItemInstance CreateInstance()
    {
        return new Armor(data);
    }
}