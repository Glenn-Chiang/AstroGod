using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StackableInventory
{
    private readonly int capacity = 10;

    [SerializeField] private List<ItemStack> itemsSlots = new();
    public IReadOnlyList<ItemStack> ItemSlots => itemsSlots;

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
            itemsSlots.Add(new ItemStack(itemData, amountToAdd));
            return true;
        }

        return false;
    }

    public ItemStack RemoveItem(int index, int amountToRemove = 1)
    {
        if (!ValidateIndex(index)) return null;

        var itemStack = itemsSlots[index];
        int amountRemoved = Math.Min(itemStack.amount, amountToRemove);
        itemStack.amount -= amountRemoved;
        if (itemStack.amount == 0)
        {
            itemsSlots.RemoveAt(index);
        }
        return new ItemStack(itemStack.itemData, amountRemoved);
    }

    private bool ValidateIndex(int index)
    {
        return index >= 0 && index < itemsSlots.Count;
    }
}

public class ItemStack
{
    public ItemData itemData;
    public int amount;

    public ItemStack(ItemData _itemData, int _amount)
    {
        itemData = _itemData;
        amount = _amount;
    }
}

