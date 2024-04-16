using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] public Weapon EquippedWeapon { get; private set; }
    
    private void Start()
    {
            
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }

    public void RemoveWeapon(int weaponNumber)
    {
        weapons.RemoveAt(weaponNumber);
    }

    public void EquipWeapon(int weaponNumber)
    {
        EquippedWeapon = weapons[weaponNumber];
    }
}