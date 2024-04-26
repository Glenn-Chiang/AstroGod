using System;
using System.Collections.Generic;
using UnityEngine;

public class StackableInventory : IInventory
{
    private readonly int capacity;
    int IInventory.Capacity => capacity;

    [SerializeField] private List<ItemStack> itemStacks = new();
    public IReadOnlyList<ItemStack> ItemStacks => itemStacks;
    IReadOnlyList<IItem> IInventory.Items => itemStacks;

    public StackableInventory(int _capacity)
    {
        capacity = _capacity;
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

