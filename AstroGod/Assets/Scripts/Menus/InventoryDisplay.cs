using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    private IInventory inventory;
    [SerializeField] protected int inventoryNumber;

    [SerializeField] private List<InventorySlotDisplay> slots;
    protected readonly string placeholderName = "Empty";

    private void Start()
    {
        inventory = inventoryManager.Inventories[inventoryNumber];
    }

    private void Update()
    {
        UpdateDisplay();
    }

    protected virtual void UpdateDisplay()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            var slot = slots[i];
            

            if (i > inventory.Items.Count - 1 || inventory.Items[i] == null)
            {
                ClearSlot(slot);
                return;
            }

            var item = inventory.Items[i];
            FillSlot(slot, item, i);
        }
    }

    protected virtual void ClearSlot(InventorySlotDisplay slot)
    {
        slot.iconDisplay.sprite = null;
        slot.iconDisplay.enabled = false;
        slot.nameDisplay.text = placeholderName;
    }

    protected virtual void FillSlot(InventorySlotDisplay slot, IItem item, int index)
    {
        slot.iconDisplay.sprite = item.ItemData.Icon;
        slot.iconDisplay.SetNativeSize();
        slot.iconDisplay.enabled = true;
        slot.nameDisplay.text = $"[{index + 1}] " + item.ItemData.Name;  
    }
}