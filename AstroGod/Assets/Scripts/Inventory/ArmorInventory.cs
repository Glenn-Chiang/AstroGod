using System;
using UnityEngine;

[Serializable]
public class ArmorInventory : InstanceInventory<Armor>
{
    [SerializeField] private int capacity = 2;
    public override int Capacity => capacity;
}