using UnityEngine;

public abstract class InventoryManager : MonoBehaviour
{
    public virtual bool AddItemInstance(ItemInstance itemInstance) { return false; }

    public virtual bool AddItemStack(ItemStack itemStack) { return false; }

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
        if (itemStack.amount > 0)
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
