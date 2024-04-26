using System;

public abstract class ItemInstance : IItem
{
    public virtual ItemData ItemData { get; }
}

[Serializable]
public abstract class ItemInstance<T>: ItemInstance where T : ItemData
{
    public T Data { get; }
    public override ItemData ItemData => Data;

    public ItemInstance(T data)
    {
        Data = data;
    }
}

