public abstract class ItemInstance<T> where T : ItemData
{
    public T Data { get; protected set; }

    public ItemInstance(T data)
    {
        Data = data;
    }
}