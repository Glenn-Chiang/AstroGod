using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
    public Weapon EquippedWeapon { get; set; }
    

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
        EquippedWeapon = weapon; // Equip the weapon that was just added
    }

    public void RemoveWeapon(Weapon weapon)
    {
        weapons.Remove(weapon);
        EquippedWeapon = null;
    }

    public void EquipWeapon(int weaponNumber)
    {
        EquippedWeapon = weapons[weaponNumber];
    }
}