using System.Collections.Generic;

public interface IInstanceInventory 
{
    public IReadOnlyList<IItemInstance> Items { get; }
    public void SelectItem(int index);
    public IItemInstance SelectedItem { get; }
    public IItemInstance RemoveSelected();
}
