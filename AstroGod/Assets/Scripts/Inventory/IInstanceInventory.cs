using System.Collections.Generic;

public interface IInstanceInventory 
{
    public IReadOnlyList<IItem> Items { get; }
    public void SelectItem(int index);
    public IItem SelectedItem { get; }
    public IItem RemoveSelected();
}
