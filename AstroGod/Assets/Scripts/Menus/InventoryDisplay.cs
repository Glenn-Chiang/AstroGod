using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInventoryDisplay<T> : MonoBehaviour where T : InventorySlot
{
    [SerializeField] protected InventoryManager inventoryManager;
    protected virtual IInventory Inventory { get; private set; }
    [SerializeField] protected int inventoryNumber;
    [SerializeField] private string selectedText; // Text to display under selected item
    protected readonly string placeholderName = "Empty";
    [SerializeField] protected List<T> slots;

    private void Start()
    {
        SetInventory();
    }

    protected virtual void SetInventory()
    {
        Inventory = inventoryManager.Inventories[inventoryNumber];
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
            

            if (i > Inventory.Items.Count - 1 || Inventory.Items[i] == null)
            {
                ClearSlot(slot);
                return;
            }

            var item = Inventory.Items[i];
            FillSlot(slot, item, i, Inventory.SelectedItem == item);
        }
    }

    protected virtual void ClearSlot(InventorySlot slot)
    {
        slot.iconDisplay.sprite = null;
        slot.iconDisplay.enabled = false;
        slot.nameDisplay.text = placeholderName;
    }

    protected virtual void FillSlot(InventorySlot slot, IItem item, int index, bool isSelected)
    {
        slot.iconDisplay.sprite = item.ItemData.Icon;
        slot.iconDisplay.SetNativeSize();
        slot.iconDisplay.enabled = true;
        slot.nameDisplay.text = $"[{index + 1}] " + item.ItemData.Name;

        if (isSelected)
        {
            slot.nameDisplay.text += $"<br>{selectedText}";
        }
    }
}

public class InventoryDisplay : BaseInventoryDisplay<InventorySlot>
{

}