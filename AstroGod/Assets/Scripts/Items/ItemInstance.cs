public abstract class ItemInstance
{
    public abstract ItemData Data { get; }
}

public abstract class ItemInstance<T>: ItemInstance where T : ItemData
{
    public T ItemData { get; }
    public override ItemData Data => ItemData;

    public ItemInstance(T data)
    {
        ItemData = data;
    }

}