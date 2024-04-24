using UnityEngine;

public abstract class InventoryManager : MonoBehaviour
{
    protected bool AddItemInstance<T>(T itemInstance, InstanceInventory<T> inventory) where T : ItemInstance
    {
        if (inventory.AddItem(itemInstance))
        {
            Debug.Log($"Added {itemInstance.ItemData.Name}");
            return true;
        }
        return false;
    }

    protected void DropItemInstance<T>(InstanceInventory<T> inventory) where T : ItemInstance
    {
        var itemInstance = inventory.RemoveSelected();
        if (itemInstance != null)
        {
            // Spawn the corresponding ItemPickUp prefab and transfer the item instance into the prefab
            var itemPickUp = Instantiate(itemInstance.ItemData.PickUpPrefab, transform.position, transform.rotation);
            itemPickUp.item = itemInstance;
            Debug.Log($"Dropped {itemInstance.ItemData.Name}");
        }
    }
    protected void DropItemStack(StackableInventory inventory, int index, int amountToDrop = 1)
    {
        var itemStack = inventory.RemoveItem(index, amountToDrop);
        if (itemStack.amount > 0)
        {
            var itemPickUp = Instantiate(itemStack.ItemData.PickUpPrefab, transform.position, transform.rotation);
            itemPickUp.item = itemStack;
            Debug.Log($"Dropped {itemStack.amount} {itemStack.ItemData.name}");
        }
    }
}
