using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform weaponSlot;

    private int maxWeapons = 4; // Max number of weapons the player can add
    [SerializeField] private List<Weapon> weapons;
    public Weapon equippedWeapon;

    public void AddWeapon(Weapon weaponPrefab, out bool ableToAdd)
    {
        if (weapons.Count == maxWeapons)
        {
            ableToAdd = false;
            return;
        }

        var weapon = Instantiate(weaponPrefab, weaponSlot);
        weapon.gameObject.SetActive(false);
        weapons.Add(weapon);

        EquipWeapon(weapons.Count - 1); // Equip the weapon that was just added
        ableToAdd = true;
    }

    public void EquipWeapon(int index)
    {
        // If invalid index is entered, don't do anything
        if (index < 0 || index > weapons.Count - 1)
        {
            return;
        }

        // Unequip currently equipped weapon
        if (equippedWeapon != null)
        {
            equippedWeapon.gameObject.SetActive(false);
        }

        // Equip selected weapon
        equippedWeapon = weapons[index];        
        equippedWeapon.gameObject.SetActive(true);
    }
    
    public void DropWeapon()
    {
        if (equippedWeapon == null) return;

        // Spawn the corresponding pickup item
        WeaponPickUp weaponPickUp = Instantiate(equippedWeapon.PickUp, transform.position, transform.rotation);
        //weaponPickUp.weapon = equippedWeapon.;
        
        Destroy(equippedWeapon.gameObject);
        
        weapons.Remove(equippedWeapon);
        equippedWeapon = null;

        // Reset EquippedWeapon to the first weapon in list, if any
        if (weapons.Count > 0)
        {
            equippedWeapon = weapons[0];
            equippedWeapon.gameObject.SetActive(true);
        }
    }
}