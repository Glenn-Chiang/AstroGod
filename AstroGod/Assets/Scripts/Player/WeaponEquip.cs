using UnityEngine;

public class WeaponEquip : MonoBehaviour
{
    private GameObject equippedWeaponModel;
    private WeaponController EquippedWeapon
    {
        get
        {
            if (equippedWeaponModel == null) return null;
            var weapon = equippedWeaponModel.GetComponent<WeaponController>();
            weapon.ammoManager = ammoManager;
            return weapon;
        }
    }
    private WeaponInventory weaponInventory;

    private AmmoManager ammoManager;

    private void Start()
    {
        var player = PlayerController.Instance;
        weaponInventory = player.InventoryManager.weaponInventory;
        ammoManager = player.AmmoManager;
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
        equippedWeaponModel = Instantiate(selectedWeapon.ItemData.ModelPrefab, transform);
        EquippedWeapon.weaponInstance = selectedWeapon;
    }
}