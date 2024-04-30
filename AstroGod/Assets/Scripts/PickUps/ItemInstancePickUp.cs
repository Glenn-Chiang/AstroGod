using UnityEngine;

public abstract class ItemInstancePickUp : ItemPickUp
{
    public IItemInstance itemInstance;
    public override IItem Item => itemInstance;

    protected abstract IItemInstance CreateItem();

    private void Awake()
    {
        itemInstance = CreateItem();
    }

    public override bool PickUp(InventoryManager inventoryManager)
    {
        return inventoryManager.AddItemInstance(itemInstance);
    }
}