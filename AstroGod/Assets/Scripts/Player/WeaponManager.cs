using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private GameObject equippedWeapon;
    private WeaponInventory weaponInventory;

    private void Start()
    {
        weaponInventory = PlayerController.Instance.InventoryManager.WeaponInventory;
    }

    private void Update()
    {
        UpdateEquipped();
    }

    private void UpdateEquipped()
    {
        var selectedWeapon = weaponInventory.SelectedItem;
        
        if (selectedWeapon == null && equippedWeapon == null) return;

        // If no weapon is selected but a weapon is equipped, destroy it
        if (selectedWeapon == null && equippedWeapon != null)
        {
            Destroy(equippedWeapon);
            return;
        }

        // If a weapon is selected but no weapon is equipped, equip it
        if (equippedWeapon == null)
        {
            EquipWeapon(selectedWeapon);
            return;
        }

        // If a weapon is equipped but it is not the selectedWeapon, destroy the current equipped weapon and equip the selectedWeapon by instantiating its model prefab
        if (selectedWeapon != equippedWeapon.GetComponent<WeaponController>().weaponInstance)
        {
            Destroy(equippedWeapon);
            EquipWeapon(selectedWeapon);
            return;
        }
    }

    private void EquipWeapon(Weapon selectedWeapon)
    {
        equippedWeapon = Instantiate(selectedWeapon.Data.ModelPrefab, transform);
        equippedWeapon.GetComponent<WeaponController>().weaponInstance = selectedWeapon;
    }
}