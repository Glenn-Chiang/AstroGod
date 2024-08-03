using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform weaponSlot; // Parent gameobject in which weapons will be instantiated

    [SerializeField] private int weaponLimit = 3;

    [SerializeField] private List<WeaponData> weapons;
    private int selectedIndex = 0;
    public WeaponData SelectedWeapon => weapons.Count > 0 ? weapons[selectedIndex] : null;
    private WeaponController equippedWeapon;
    public WeaponController EquippedWeapon => equippedWeapon;

    [SerializeField] private AmmoManager ammoManager; // Can be null to effectively allow infinite ammo

    private void Awake()
    {
        // Equip first weapon by default
        if (weapons.Count >= 0)
        {
            EquipWeapon(0);
        }
    }

    public void FireWeapon()
    {
        if (equippedWeapon != null && (ammoManager == null || ammoManager.ConsumeAmmo(SelectedWeapon.AmmoCost)))
        {
            equippedWeapon.HandleFire();
        }
    }

    public void EquipWeapon(int index)
    {
        if (index < 0 || index >= weapons.Count) return; // Invalid index

        if (equippedWeapon != null)
        {
            if (index == selectedIndex) return; // Already equipped same weapon
            else
            {
                Destroy(equippedWeapon.gameObject); // Unequip currently equipped weapon
            }
        }

        selectedIndex = index;
        equippedWeapon = Instantiate(SelectedWeapon.Controller, weaponSlot);
    }

    public void SelectNextWeapon()
    {
        if (weapons.Count <= 2) return;

        if (selectedIndex < weapons.Count - 1)
        {
            EquipWeapon(selectedIndex + 1);
            return;
        }
        if (selectedIndex == weapons.Count - 1)
        {
            EquipWeapon(0);
            return;
        }
    }

    public void SelectPrevWeapon()
    {
        if (weapons.Count <= 2) return;

        if (selectedIndex > 0)
        {
            EquipWeapon(selectedIndex - 1);
            return;
        }
        if (selectedIndex == 0)
        {
            EquipWeapon(weapons.Count - 1);
            return;
        }
    }

    public bool AddWeapon(WeaponData weapon)
    {
        if (weapons.Contains(weapon) || weapons.Count == weaponLimit)
        {
            return false;
        } else
        {
            weapons.Add(weapon);
            return true;
        }
    }
}