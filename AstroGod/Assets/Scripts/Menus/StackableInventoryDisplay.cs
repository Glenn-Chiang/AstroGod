using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StackableInventoryDisplay : MonoBehaviour
{
    private static string placeholderName = "Empty";

    public void UpdateInventoryDisplay(StackableInventory inventory, List<RectTransform> slots)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            var slot = slots[i];
            var iconDisplay = slot.GetComponentInChildren<Image>();
            var nameDisplay = slot.GetComponentInChildren<TMP_Text>();
            var amountDisplay = slot.GetComponentInChildren<RectTransform>();

            if (i > inventory.ItemSlots.Count - 1 || inventory.ItemSlots[i] == null)
            {
                iconDisplay.sprite = null;
                iconDisplay.enabled = false;
                nameDisplay.text = placeholderName;
                return;
            }

            var item = inventory.ItemSlots[i];
            iconDisplay.sprite = item.itemData.Icon;
            iconDisplay.SetNativeSize();
            iconDisplay.enabled = true;
            nameDisplay.text = $"[{i + 1}] " + item.itemData.Name;

          
        }
    }
}