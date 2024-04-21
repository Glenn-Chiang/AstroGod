using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    public IInventory weaponInventory;
    public IInventory armorInventory;

    public List<RectTransform> weaponSlots;
    public List<RectTransform> armorSlots;

    private string placeholderItemName = "Empty";

    private void Start()
    {
        weaponInventory = PlayerController.Instance.InventoryManager.WeaponInventory;
        armorInventory = PlayerController.Instance.InventoryManager.ArmorInventory;
    }

    private void Update()
    {
        UpdateInventoryDisplay(weaponInventory, weaponSlots);
        UpdateInventoryDisplay(armorInventory, armorSlots);
    }

    private void UpdateInventoryDisplay(IInventory inventory, List<RectTransform> slots)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            var slot = slots[i];
            var iconImage = slot.GetComponentInChildren<Image>();
            var nameText = slot.GetComponentInChildren<TMP_Text>();

            if (i > inventory.Items.Count - 1 || inventory.Items[i] == null)
            {
                iconImage.sprite = null;
                iconImage.enabled = false;
                nameText.text = placeholderItemName;

            } else
            {
                var item = inventory.Items[i];
                iconImage.sprite = item.Data.Icon;
                iconImage.SetNativeSize();
                iconImage.enabled = true;
                nameText.text = item.Data.Name;
            }
        }
    }
}