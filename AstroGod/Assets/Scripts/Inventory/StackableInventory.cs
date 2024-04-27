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

    private int selectedIndex = -1;

    public ItemStack SelectedItem
    {
        get
        {
            if (!ValidateIndex(selectedIndex)) return null;
            return itemStacks[selectedIndex];
        }
    }
    IItem IInventory.SelectedItem => SelectedItem;

    public StackableInventory(int _capacity)
    {
        capacity = _capacity;
    }

    public ItemStack AddItem(ItemStack _itemStack)
    {
        int remainderAmount = _itemStack.Amount;

        foreach (var itemStack in itemStacks)
        {
            if (itemStack.itemData == _itemStack.itemData)
            {
                remainderAmount = itemStack.AddAmount(_itemStack.Amount);
                if (remainderAmount == 0)
                {
                    return null;
                }
            }
        }

        if (ItemStacks.Count < capacity)
        {
            itemStacks.Add(_itemStack);
            return null;
        }

        return new ItemStack(_itemStack.itemData, remainderAmount);
    }

    public ItemStack RemoveItem(int index, int amountToRemove = 1)
    {
        if (!ValidateIndex(index)) return null;

        var itemStack = itemStacks[index];
        int amountRemoved = itemStack.ReduceAmount(amountToRemove);
        if (itemStack.Amount == 0)
        {
            itemStacks.RemoveAt(index);
        }
        return new ItemStack(itemStack.itemData, amountRemoved);
    }

    public ItemStack RemoveSelected()
    {
        if (SelectedItem == null) return null;
        return RemoveItem(selectedIndex);
    }
    IItem IInventory.RemoveSelected() => RemoveSelected();

    public void ConsumeSelected(GameObject consumer)
    {
        if (SelectedItem == null) return;

        SelectedItem.Consume(consumer);
        if (SelectedItem.Amount == 0)
        {
            itemStacks.Remove(SelectedItem);
        }
    }

    public void SelectItem(int index)
    {
        if (!ValidateIndex(index)) return;
        selectedIndex = index;
        Debug.Log($"Selected {SelectedItem.itemData.Name}");
    }
    
    private bool ValidateIndex(int index)
    {
        return index >= 0 && index < itemStacks.Count;
    }
}

