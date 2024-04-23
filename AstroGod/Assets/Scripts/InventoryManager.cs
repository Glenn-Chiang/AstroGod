using UnityEngine;

public abstract class InventoryManager : MonoBehaviour
{
    public abstract bool AddItem(IItemInstance item);
    public abstract bool AddItem(ItemData itemData, int amountToAdd = 1);

    // Drop the selected item from the specified inventory into the game world
    // Spawn the corresponding ItemPickUp prefab and transfer the item instance into the prefab
    protected void DropItemInstance(IInstanceInventory inventory)
    {
        var removedItem = inventory.RemoveSelected();
        if (removedItem != null)
        {
            var droppedItem = Instantiate((InstancedItemPickUp)removedItem.Data.PickUpPrefab, transform.position, transform.rotation);
            droppedItem.itemInstance = removedItem;
            Debug.Log($"Dropped {removedItem.Data.Name}");
        }
    }
    protected void DropItem(StackableInventory inventory, int index, int amountToDrop = 1)
    {
        var itemStack = inventory.RemoveItem(index, amountToDrop);
        if (itemStack.amount > 0)
        {
            var droppedStack = Instantiate((ConsumeableItemPickUp)itemStack.itemData.PickUpPrefab, transform.position, transform.rotation);
            droppedStack.amount = itemStack.amount;
            Debug.Log($"Dropped {itemStack.amount} {itemStack.itemData.name}");
        }
    }
}
