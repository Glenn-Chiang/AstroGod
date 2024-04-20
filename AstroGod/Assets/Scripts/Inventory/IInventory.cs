using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IInventory 
{
    public IReadOnlyList<IItem> Items { get; }
    public IItem SelectedItem { get; }
    public IItem RemoveSelected();
}

[Serializable]
public abstract class IInventory<T>: IInventory 
    where T : class, IItem
{
    IReadOnlyList<IItem> IInventory.Items => items;
    IItem IInventory.SelectedItem => SelectedItem;
    IItem IInventory.RemoveSelected() => RemoveSelected();

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