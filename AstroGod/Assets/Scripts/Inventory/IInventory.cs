using System;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory 
{
    public IReadOnlyList<IItem> Items { get; }
    public IItem SelectedItem { get; }
    public IItem RemoveSelected();
}

public abstract class Inventory<T>: IInventory where T : class, IItem
{
    IReadOnlyList<IItem> IInventory.Items => Items;
    IItem IInventory.SelectedItem => SelectedItem;
    IItem IInventory.RemoveSelected() => RemoveSelected();

    public abstract int Capacity { get; }

    public List<T> Items { get; }

    private int selectedIndex = -1; // No item selected by default

    public T SelectedItem
    {
        get
        {
            if (!ValidateIndex(selectedIndex)) return null;
            return Items[selectedIndex];
        }
    }

    public bool AddItem(T item)
    {
        // Don't exceed capacity and don't store multiple references to the same item
        if (Items.Count == Capacity || Items.Contains(item)) return false;
        Items.Add(item);
        return true;
    }

    public T RemoveSelected()
    {
        if (SelectedItem == null) return default;

        var itemToRemove = SelectedItem;
        Items.Remove(itemToRemove);
        SelectItem(-1); // After the selected item is removed, no item is selected
        return itemToRemove;
    }

    public void SelectItem(int index)
    {
        if (!ValidateIndex(index)) return;
        selectedIndex = index;
        Debug.Log($"Selected {SelectedItem.Data.itemName}");
    }

    private bool ValidateIndex(int index)
    {
        return index >= 0 && index < Items.Count;
    }
}