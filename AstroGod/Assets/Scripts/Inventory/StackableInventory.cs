using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class StackableInventory
{
    private readonly int capacity = 10;

    [SerializeField] private List<ItemSlot> itemsSlots;

    public bool AddItem(ItemData itemData, int amountToAdd)
    {
        // If there is already a slot containing this ItemData, simply increment its amount
        foreach (var itemSlot in itemsSlots)
        {
            if (itemSlot.itemData == itemData)
            {
                itemSlot.amount += amountToAdd;
                return true;
            }
        }

        // If there is sufficient capacity, add a new slot for this ItemData
        if (itemsSlots.Count < capacity)
        {
            itemsSlots.Add(new ItemSlot(itemData, amountToAdd));
            return true;
        }

        return false;
    }

    public void ReduceItem(int index)
    {
        if (!ValidateIndex(index)) return;

        var itemSlot = itemsSlots[index];
        itemSlot.amount -= 1;

        // If amount of item is reduced to 0, remove its slot
        if (itemSlot.amount == 0)
        {
            itemsSlots.RemoveAt(index);
        }
    }

    // Remove the whole stack of the ItemData at this slot
    public ItemData RemoveItem(int index)
    {
        if (!ValidateIndex(index)) return null;

        itemsSlots.RemoveAt(index);
        return itemsSlots[index].itemData;
    }

    private bool ValidateIndex(int index)
    {
        return index >= 0 && index < itemsSlots.Count;
    }
}

public class ItemSlot
{
    public ItemData itemData;
    public int amount;

    public ItemSlot(ItemData _itemData, int _amount)
    {
        itemData = _itemData;
        amount = _amount;
    }
}

