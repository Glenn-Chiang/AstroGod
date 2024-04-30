using System;

public interface IItemInstance : IItem
{
    ItemData Data { get; }
    ItemData IItem.ItemData => Data;
}

[Serializable]
public abstract class ItemInstance<T>: IItemInstance where T : ItemData
{
    public T ItemData { get; }
    ItemData IItemInstance.Data => ItemData;

    public ItemInstance(T data)
    {
        ItemData = data;
    }
}

