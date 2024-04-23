using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class StackableInventoryDisplay : MonoBehaviour
{
    [SerializeField] protected StackableInventory inventory;
    [SerializeField] private List<StackableInventorySlotDisplay> slots;

    private readonly string placeholderName = "Empty";

    private void Update()
    {
        UpdateInventoryDisplay();
    }

    private void UpdateInventoryDisplay()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            var slot = slots[i];
            var iconDisplay = slot.iconDisplay;
            var nameDisplay = slot.nameDisplay;
            var amountDisplay = slot.amountDisplay;

            if (i > inventory.ItemSlots.Count - 1 || inventory.ItemSlots[i] == null)
            {
                iconDisplay.sprite = null;
                iconDisplay.enabled = false;
                amountDisplay.enabled = false;
                nameDisplay.text = placeholderName;
                return;
            }

            var itemStack = inventory.ItemSlots[i];
            iconDisplay.sprite = itemStack.itemData.Icon;
            iconDisplay.SetNativeSize();
            iconDisplay.enabled = true;
            nameDisplay.text = $"[{i + 1}] " + itemStack.itemData.Name;
            amountDisplay.text = itemStack.amount.ToString();
            amountDisplay.enabled = true;
        }
    }
}