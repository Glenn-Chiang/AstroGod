using System;

public abstract class ItemInstance : IItem
{
    public ItemData ItemData { get; }
}

[Serializable]
public abstract class ItemInstance<T>: ItemInstance where T : ItemData
{
    public new T ItemData { get; }

    public ItemInstance(T data)
    {
        ItemData = data;
    }
}

