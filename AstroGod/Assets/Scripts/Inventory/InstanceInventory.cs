using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public abstract class InstanceInventory<T> : IInstanceInventory where T : class, IItemInstance
{
    IReadOnlyList<IItemInstance> IInstanceInventory.Items => items;
    IItemInstance IInstanceInventory.SelectedItem => SelectedItem;
    IItemInstance IInstanceInventory.RemoveSelected() => RemoveSelected();

    public abstract int Capacity { get; }

    [SerializeField] private List<T> items = new();

    private int selectedIndex = -1; // No item selected by default

    public T SelectedItem
    {
        get
        {
            if (!ValidateIndex(selectedIndex)) return null;
            return items[selectedIndex];
        }
    }

    public bool AddItem(T item)
    {
        // Don't exceed capacity and don't store multiple references to the same item
        if (items.Count == Capacity || items.Contains(item)) return false;
        items.Add(item);
        Debug.Log(items.Count);
        return true;
    }

    public T RemoveSelected()
    {
        if (SelectedItem == null) return null;

        var itemToRemove = SelectedItem;
        items.Remove(itemToRemove);
        SelectItem(-1); // After the selected item is removed, no item is selected
        return itemToRemove;
    }

    public void SelectItem(int index)
    {
        if (!ValidateIndex(index)) return;
        selectedIndex = index;
        Debug.Log($"Selected {SelectedItem.Data.Name}");
    }

    private bool ValidateIndex(int index)
    {
        return index >= 0 && index < items.Count;
    }
}