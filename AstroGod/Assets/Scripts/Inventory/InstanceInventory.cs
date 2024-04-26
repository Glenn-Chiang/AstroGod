using System.Collections.Generic;
using UnityEngine;

public interface InstanceInventory : IInventory
{
    abstract int IInventory.Capacity { get; }
    abstract IReadOnlyList<IItem> IInventory.Items { get; }
   
    abstract IItem IInventory.RemoveSelected();
}


public class InstanceInventory<T>: InstanceInventory where T : ItemInstance
{
    public readonly int capacity;
    int IInventory.Capacity => capacity;

    [SerializeField] private List<T> items = new();
    IReadOnlyList<IItem> IInventory.Items => items;

    private int selectedIndex = -1; // No item selected by default

    public T SelectedItem
    {
        get
        {
            if (!ValidateIndex(selectedIndex)) return null;
            return items[selectedIndex];
        }
    }

    public InstanceInventory(int _capacity)
    {
        capacity = _capacity;
    }

    public bool AddItem(T item)
    {
        // Don't exceed capacity and don't store multiple references to the same item
        if (items.Count == capacity || items.Contains(item)) return false;
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
    IItem IInventory.RemoveSelected() => RemoveSelected();

    public void SelectItem(int index)
    {
        if (!ValidateIndex(index)) return;
        selectedIndex = index;
        Debug.Log($"Selected {SelectedItem.ItemData.Name}");
    }
    private bool ValidateIndex(int index)
    {
        return index >= 0 && index < items.Count;
    }
}