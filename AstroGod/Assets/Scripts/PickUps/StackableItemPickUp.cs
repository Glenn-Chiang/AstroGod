using UnityEngine;

public class StackableItemPickUp : ItemPickUp
{
    [SerializeField] private StackableItem itemData;

    private int amount = 1;

    public ItemStack itemStack;
    public override IItem Item => itemStack;

    private void Awake()
    {
        itemStack = new(itemData, amount);
    }

    public override bool PickUp(InventoryManager inventoryManager)
    {
        var remainingStack = inventoryManager.AddItemStack(itemStack);
        
        // Full stack was added
        if (remainingStack == null)
        {
            return true;
        } else
        {
            amount -= remainingStack.Amount;
            return false;
        }
    }
}
