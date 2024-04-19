using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ItemData
{
    // Base values for weapon stats
    public float baseFireRate;
    public float baseDamage;
    public float ammoCost;
}