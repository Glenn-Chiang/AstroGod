using System.Collections.Generic;
using UnityEngine;

public class StackableInventoryDisplay : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    private StackableInventory inventory;
    [SerializeField] protected int inventoryNumber;


    [SerializeField] private List<StackableInventorySlotDisplay> slots;
    private readonly string placeholderName = "Empty";

    private void Start()
    {
        inventory = inventoryManager.StackableInventories[inventoryNumber];
    }

    private void Update()
    {
        UpdateInventoryDisplay();
    }

    private void UpdateInventoryDisplay()
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
            FillSlot(slot, itemStack, i);
        }
    }

    protected virtual void ClearSlot(StackableInventorySlotDisplay slot)
    {
        slot.iconDisplay.sprite = null;
        slot.iconDisplay.enabled = false;
        slot.nameDisplay.text = placeholderName;
    }

    protected virtual void FillSlot(StackableInventorySlotDisplay slot, ItemStack itemStack, int index)
    {
        slot.iconDisplay.sprite = itemStack.itemData.Icon;
        slot.iconDisplay.SetNativeSize();
        slot.iconDisplay.enabled = true;
        slot.nameDisplay.text = $"[{index + 1}] " + itemStack.itemData.Name;
        slot.amountDisplay.text = itemStack.Amount.ToString();
        slot.amountDisplay.enabled = true;
    }
}