using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

[Serializable, Inspectable]
public class WeaponManager
{
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] public Weapon EquippedWeapon { get; private set; }

    public WeaponManager()
    {
        EquippedWeapon = weapons[0];
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }

    public void DropWeapon(int weaponNumber)
    {
        weapons.RemoveAt(weaponNumber);
    }

    public void EquipWeapon(int weaponNumber)
    {
        EquippedWeapon = weapons[weaponNumber];
    }
}