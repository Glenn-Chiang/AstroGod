using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform weaponSlot; // Parent gameobject in which weapons will be instantiated

    [SerializeField] private int weaponLimit = 3;

    [SerializeField] private List<WeaponData> weapons;
    private int selectedIndex = 0;
    public WeaponData SelectedWeapon => weapons[selectedIndex];
    private WeaponController equippedWeapon;

    [SerializeField] private AmmoManager ammoManager; // Can be null to effectively allow infinite ammo

    public void FireWeapon()
    {
        if (equippedWeapon != null && (ammoManager == null || ammoManager.ConsumeAmmo(SelectedWeapon.AmmoCost)))
        {
            equippedWeapon.HandleFire();
        }
    }

    private void EquipWeapon()
    {
        equippedWeapon = Instantiate(SelectedWeapon.Controller, weaponSlot);
    }

    public void SelectWeapon(int index)
    {
        if (index < 0 || index >= weapons.Count) return; // Invalid index
        if (index == selectedIndex) return; // Already selected

        if (equippedWeapon != null)
        {
            Destroy(equippedWeapon.gameObject); // Remove currently selected weapon
        }

        selectedIndex = index;
        EquipWeapon();

    }

    public void SelectNextWeapon()
    {
        if (weapons.Count <= 2) return;

        if (selectedIndex < weapons.Count - 1)
        {
            SelectWeapon(selectedIndex + 1);
            return;
        }
        if (selectedIndex == weapons.Count - 1)
        {
            SelectWeapon(0);
            return;
        }
    }

    public void SelectPrevWeapon()
    {
        if (weapons.Count <= 2) return;

        if (selectedIndex > 0)
        {
            SelectWeapon(selectedIndex - 1);
            return;
        }
        if (selectedIndex == 0)
        {
            SelectWeapon(weapons.Count - 1);
            return;
        }
    }

    public void SelectRandomWeapon()
    {
        SelectWeapon(UnityEngine.Random.Range(0, weapons.Count));
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