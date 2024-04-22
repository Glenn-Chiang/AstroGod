using System;

public interface IItem
{
    public ItemData Data { get; }
}

[Serializable]
public abstract class ItemInstance<T>: IItem where T : ItemData
{
    public T Data { get; }
    ItemData IItem.Data => Data;

    public ItemInstance(T data)
    {
        Data = data;
    }
}

