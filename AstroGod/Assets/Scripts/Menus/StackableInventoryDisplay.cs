public class StackableInventoryDisplay : BaseInventoryDisplay<StackableInventorySlot>
{
    private StackableInventory inventory;
    protected override IInventory Inventory => inventory;

    protected override void SetInventory()
    {
        inventory = inventoryManager.StackableInventories[inventoryNumber];
    }

    protected override void UpdateDisplay()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            var slot = slots[i];

            if (i > inventory.ItemStacks.Count - 1 || inventory.ItemStacks[i] == null)
            {
                ClearSlot(slot);
                return;
            }

            var itemStack = inventory.ItemStacks[i];
            FillSlot(slot, itemStack, i, inventory.SelectedItem == itemStack);
        }
    }

    protected virtual void ClearSlot(StackableInventorySlot slot)
    {
        base.ClearSlot(slot);
        slot.amountDisplay.enabled = false;
    }

    protected virtual void FillSlot(StackableInventorySlot slot, ItemStack itemStack, int index, bool isSelected)
    {
        base.FillSlot(slot, itemStack, index, isSelected);
        slot.amountDisplay.text = $"{itemStack.Amount}/{itemStack.itemData.StackLimit}";
        slot.amountDisplay.enabled = true;
    }
}