public abstract class ItemInstance
{
    public abstract ItemData ItemData { get; }
}

public abstract class ItemInstance<T>: ItemInstance where T : ItemData
{
    public T Data { get; }
    public override ItemData ItemData => Data;

    public ItemInstance(T data)
    {
        Data = data;
    }

}