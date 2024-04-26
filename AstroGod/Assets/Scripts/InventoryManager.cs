using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryManager : MonoBehaviour
{
    public abstract List<IInventory> Inventories { get; }
    public abstract List<StackableInventory> StackableInventories { get; } 
    public abstract int SelectedInventoryIndex { get; }
    public virtual bool AddItemInstance(ItemInstance itemInstance) { return false; }
    public virtual ItemStack AddItemStack(ItemStack itemStack) { return null; }

    protected void DropItem(InstanceInventory inventory)
    {
        var item = inventory.RemoveSelected();
        if (item != null)
        {
            InstantiatePickUp(item);
        }
    }

    protected void DropItem(StackableInventory inventory)
    {
        var itemStack = inventory.RemoveSelected();
        if (itemStack != null && itemStack.Amount > 0)
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
