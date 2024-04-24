public class ItemStack : IItem
{
    public ItemData ItemData { get; }
    public int amount;

    public ItemStack(ItemData _itemData, int _amount)
    {
        ItemData = _itemData;
        amount = _amount;
    }
}
