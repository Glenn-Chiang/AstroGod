using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private GameObject equippedWeaponModel;
    private WeaponController EquippedWeapon
    {
        get
        {
            if (equippedWeaponModel == null) return null;
            return equippedWeaponModel.GetComponent<WeaponController>();
        }
    }
    private WeaponInventory weaponInventory;

    private void Start()
    {
        weaponInventory = PlayerController.Instance.InventoryManager.WeaponInventory;
    }

    private void Update()
    {
        UpdateEquipped();

        if (EquippedWeapon != null && Input.GetButtonDown("Fire1"))
        {
            EquippedWeapon.Fire();
        }
    }

    private void UpdateEquipped()
    {
        var selectedWeapon = weaponInventory.SelectedItem;
        
        if (selectedWeapon == null && EquippedWeapon == null) return;

        // If no weapon is selected but a weapon is equipped, destroy it
        if (selectedWeapon == null && EquippedWeapon != null)
        {
            Destroy(equippedWeaponModel);
            return;
        }

        // If a weapon is selected but no weapon is equipped, equip it
        if (EquippedWeapon == null)
        {
            EquipWeapon(selectedWeapon);
            return;
        }

        // If a weapon is equipped but it is not the selectedWeapon, destroy the current equipped weapon and equip the selectedWeapon by instantiating its model prefab
        if (selectedWeapon != EquippedWeapon.weaponInstance)
        {
            Destroy(equippedWeaponModel);
            EquipWeapon(selectedWeapon);
            return;
        }
    }

    private void EquipWeapon(Weapon selectedWeapon)
    {
        equippedWeaponModel = Instantiate(selectedWeapon.Data.ModelPrefab, transform);
        EquippedWeapon.weaponInstance = selectedWeapon;
    }
}