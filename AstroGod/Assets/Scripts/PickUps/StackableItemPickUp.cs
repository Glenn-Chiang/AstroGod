using UnityEngine;

public class StackableItemPickUp : ItemPickUp
{
    [SerializeField] private ItemData itemData;

    private readonly int amount = 1;

    public ItemStack itemStack;
    public override IItem Item => itemStack;

    private void Awake()
    {
        itemStack = new(itemData, amount);
    }

    public override bool PickUp(InventoryManager inventoryManager)
    {
        return inventoryManager.AddItemStack(itemStack);
    }
}
