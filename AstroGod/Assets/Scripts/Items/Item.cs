using System;
using Unity.VisualScripting;


public interface IItem
{
    public ItemData Data { get; }
}

[Serializable]
public abstract class Item<T>: IItem where T : ItemData
{
    public T Data { get; }
    ItemData IItem.Data => Data;

    public Item(T data)
    {
        Data = data;
    }
}

