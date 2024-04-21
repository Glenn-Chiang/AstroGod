using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHUD : MonoBehaviour
{
    private WeaponInventory weaponInventory;

    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text nameText;
    private readonly string placeholderText = "No weapon";

    private void Start()
    {
        weaponInventory = PlayerController.Instance.InventoryManager.WeaponInventory;
        
    }
    private void Update()
    {
        var selectedWeapon = weaponInventory.SelectedItem;

        if (selectedWeapon == null)
        {
            nameText.text = placeholderText;
            iconImage.sprite = null;
            SetOpacity(iconImage, 0f);
            return;
        }

        nameText.text = selectedWeapon.Data.Name;
        iconImage.sprite = selectedWeapon.Data.Icon;
        SetOpacity(iconImage, 1f);
    }

    private void SetOpacity(Image image, float opacity)
    {
        var color = image.color;
        color.a = opacity;
        iconImage.color = color;
    }
}