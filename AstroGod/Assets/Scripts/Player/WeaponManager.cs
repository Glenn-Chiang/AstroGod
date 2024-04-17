using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform weaponSlot;
    [SerializeField] private List<Weapon> weapons;
    [SerializeReference] public Weapon equippedWeapon;

    private void Start()
    {
    }

    public void AddWeapon(Weapon weaponPrefab)
    {
        var weapon = Instantiate(weaponPrefab, weaponSlot);
        weapon.gameObject.SetActive(false);
        weapons.Add(weapon);

        EquipWeapon(weapons.Count - 1); // Equip the weapon that was just added
    }

    public void RemoveWeapon(Weapon weapon)
    {
        weapons.Remove(weapon);
        equippedWeapon = null;
    }

    public void EquipWeapon(int weaponNumber)
    {
        // Unequip currently equipped weapon
        if (equippedWeapon != null)
        {
            equippedWeapon.gameObject.SetActive(false);
        }

        // Equip selected weapon
        equippedWeapon = weapons[weaponNumber];
        equippedWeapon.gameObject.SetActive(true);
    }
}