using System;

public interface IItemInstance
{
    public ItemData Data { get; }
}

[Serializable]
public abstract class ItemInstance<T>: IItemInstance where T : ItemData
{
    public T Data { get; }
    ItemData IItemInstance.Data => Data;

    public ItemInstance(T data)
    {
        Data = data;
    }
}

