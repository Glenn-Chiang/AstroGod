public abstract class ItemInstance
{
    public ItemData ItemData { get; }

    public ItemInstance(ItemData data)
    {
        ItemData = data;
    }
}