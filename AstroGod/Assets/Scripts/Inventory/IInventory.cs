using System;
using System.Collections.Generic;

public interface IInventory
{
    public int Capacity { get; }
    public IReadOnlyList<IItem> Items { get; }
    public IItem SelectedItem { get; }
    public void SelectItem(int index);
    public IItem RemoveSelected();

}
