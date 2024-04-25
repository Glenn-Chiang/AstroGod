using UnityEngine;

public abstract class ItemInstancePickUp : ItemPickUp
{
    public ItemInstance itemInstance;
    public override IItem Item => itemInstance;

    protected abstract ItemInstance CreateItem();

    private void Awake()
    {
        itemInstance = CreateItem();
    }

    public override bool PickUp(InventoryManager inventoryManager)
    {
        return inventoryManager.AddItemInstance(itemInstance);
    }
}