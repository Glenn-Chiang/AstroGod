public class ItemStack : IItem
{
    public StackableItemData ItemData { get; }
    ItemData IItem.ItemData => ItemData;
    public int amount;

    public ItemStack(StackableItemData _itemData, int _amount)
    {
        ItemData = _itemData;
        amount = _amount;
    }
}
