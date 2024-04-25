using System.Collections.Generic;

public interface InstanceInventory
{
    public IReadOnlyList<ItemInstance> Items { get; }
    public ItemInstance SelectedItem { get; }
}
