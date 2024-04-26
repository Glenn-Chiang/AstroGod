using System.Collections.Generic;

public interface IInventory
{
    public int Capacity { get; }
    public IReadOnlyList<IItem> Items { get; }
   
}
