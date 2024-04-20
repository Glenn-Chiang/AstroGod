using System;
using UnityEngine;

[Serializable]
public class WeaponInventory :  IInventory<Weapon>
{
    [SerializeField] private int capacity = 3;
    public override int Capacity => capacity;
}