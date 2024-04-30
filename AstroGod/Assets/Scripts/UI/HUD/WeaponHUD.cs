using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHUD : MonoBehaviour
{
    private InstanceInventory<IWeapon> weaponInventory;

    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text nameText;
    private readonly string placeholderText = "No weapon";

    private void Start()
    {
        weaponInventory = PlayerController.Instance.InventoryManager.weaponInventory;
        
    }
    private void Update()
    {
        var selectedWeapon = weaponInventory.SelectedItem;

        if (selectedWeapon == null)
        {
            nameText.text = placeholderText;
            iconImage.sprite = null;
            iconImage.enabled = false;
        }
        else
        {
            nameText.text = selectedWeapon.ItemData.Name;
            iconImage.sprite = selectedWeapon.ItemData.Icon;
            iconImage.enabled = true;
        }
    }

 
}