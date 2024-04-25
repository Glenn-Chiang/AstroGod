using System.Collections.Generic;
using UnityEngine;

public abstract class InstanceInventoryDisplay : MonoBehaviour
{
    [SerializeField] protected InstanceInventory inventory;
    [SerializeField] private List<InventorySlotDisplay> slots;
    
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

            if (i > inventory.Items.Count - 1 || inventory.Items[i] == null)
            {
                iconDisplay.sprite = null;
                iconDisplay.enabled = false;
                nameDisplay.text = placeholderName;
                return;
            }
            
            var item = inventory.Items[i];
            iconDisplay.sprite = item.ItemData.Icon;
            iconDisplay.SetNativeSize();
            iconDisplay.enabled = true;
            nameDisplay.text = $"[{i+1}] " + item.ItemData.Name;
            
            if (inventory.SelectedItem == item)
            {
                // Display key prompt to drop the selected weapon
                nameDisplay.text += "<br>[G] Drop";
            }
        }
    }
}