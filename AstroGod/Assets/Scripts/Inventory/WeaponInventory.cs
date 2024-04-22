using System;
using UnityEngine;

[Serializable]
public class WeaponInventory :  InstanceInventory<Weapon>
{
    [SerializeField] private int capacity = 3;
    public override int Capacity => capacity;
}