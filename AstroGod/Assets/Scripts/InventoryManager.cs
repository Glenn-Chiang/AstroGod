using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryManager : MonoBehaviour
{
    public abstract List<IInventory> InstanceInventories { get; }
    public abstract List<StackableInventory> StackableInventories { get; } 

    public virtual bool AddItemInstance(ItemInstance itemInstance) { return false; }
    public virtual ItemStack AddItemStack(ItemStack itemStack) { return null; }

    protected void DropItemInstance<T>(InstanceInventory<T> inventory) where T : ItemInstance
    {
        var itemInstance = inventory.RemoveSelected();
        if (itemInstance != null)
        {
            InstantiatePickUp(itemInstance);
        }
    }
    protected void DropItemStack(StackableInventory inventory, int index, int amountToDrop = 1)
    {
        var itemStack = inventory.RemoveItem(index, amountToDrop);
        if (itemStack.Amount > 0)
        {
            InstantiatePickUp(itemStack);
        }
    }

    private void InstantiatePickUp(IItem item)
    {
        var itemPickUp = Instantiate(item.ItemData.PickUpPrefab, transform.position, transform.rotation);
        itemPickUp.Item = item;
        Debug.Log($"Dropped {item.ItemData.Name}");
    }
}
