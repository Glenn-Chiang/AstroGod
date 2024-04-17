using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform weaponSlot;
    [SerializeField] private List<Weapon> weapons;
    [SerializeReference] public Weapon equippedWeapon;
    private int maxWeapons = 4; // Max number of weapons the player can add

    private void Start()
    {
    }

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

    public void RemoveWeapon(Weapon weapon)
    {
        weapons.Remove(weapon);
        equippedWeapon = null;
    }

    public void EquipWeapon(int weaponIndex)
    {
        // If invalid index is entered, don't do anything
        if (weaponIndex < 0 || weaponIndex > weapons.Count - 1)
        {
            return;
        }

        // Unequip currently equipped weapon
        if (equippedWeapon != null)
        {
            equippedWeapon.gameObject.SetActive(false);
        }

        // Equip selected weapon
        equippedWeapon = weapons[weaponIndex];
        equippedWeapon.gameObject.SetActive(true);
    }
}