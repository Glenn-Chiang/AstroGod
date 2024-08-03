using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHUD : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text nameText;
    private readonly string placeholderText = "No weapon";

    private void Update()
    {
        var selectedWeapon = weaponManager.SelectedWeapon;

        if (selectedWeapon == null)
        {
            nameText.text = placeholderText;
            iconImage.sprite = null;
            iconImage.enabled = false;
        }
        else
        {
            nameText.text = selectedWeapon.Name;
            iconImage.sprite = selectedWeapon.Icon;
            iconImage.enabled = true;
        }
    }
}