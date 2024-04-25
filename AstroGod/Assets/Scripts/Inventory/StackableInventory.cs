using System;
using System.Collections.Generic;
using UnityEngine;

public class StackableInventory
{
    private readonly int capacity;

    [SerializeField] private List<ItemStack> itemStacks = new();
    public IReadOnlyList<ItemStack> ItemStacks => itemStacks;

    public StackableInventory(int _capacity)
    {
        capacity = _capacity;
    }

    public bool AddItem(ItemData itemData, int amountToAdd)
    {
        // If there is already a slot containing this ItemData, simply increment its amount
        foreach (var itemStack in itemStacks)
        {
            if (itemStack.ItemData == itemData)
            {
                itemStack.amount += amountToAdd;
                return true;
            }
        }

        // If there is sufficient capacity, add a new slot for this ItemData
        if (itemStacks.Count < capacity)
        {
            itemStacks.Add(new ItemStack(itemData, amountToAdd));
            return true;
        }

        return false;
    }

    public bool AddItem(ItemStack _itemStack)
    {
        foreach (var itemStack in itemStacks)
        {
            if (itemStack.ItemData == _itemStack.ItemData)
            {
                itemStack.amount += _itemStack.amount;
                return true;
            }
        }

        if (ItemStacks.Count < capacity)
        {
            itemStacks.Add(_itemStack);
            return true;
        }

        return false;
    }

    public ItemStack RemoveItem(int index, int amountToRemove = 1)
    {
        if (!ValidateIndex(index)) return null;

        var itemStack = itemStacks[index];
        int amountRemoved = Math.Min(itemStack.amount, amountToRemove);
        itemStack.amount -= amountRemoved;
        if (itemStack.amount == 0)
        {
            itemStacks.RemoveAt(index);
        }
        return new ItemStack(itemStack.ItemData, amountRemoved);
    }

    private bool ValidateIndex(int index)
    {
        return index >= 0 && index < itemStacks.Count;
    }
}

