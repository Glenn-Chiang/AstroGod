using UnityEngine;

public class StackableItemPickUp : ItemPickUp
{
    private readonly int amount = 1;

    protected override IItem CreateItem()
    {
        return new ItemStack(ItemData, amount);
    }
}
