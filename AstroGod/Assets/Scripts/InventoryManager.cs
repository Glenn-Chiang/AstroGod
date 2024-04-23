using UnityEngine;

public abstract class InventoryManager : MonoBehaviour
{
    public abstract bool AddItem(IItemInstance item);
    public abstract bool AddItem(ItemData itemData, int amountToAdd = 1);
    protected abstract void DropItem(IInstanceInventory inventory);
}
