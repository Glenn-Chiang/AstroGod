using System;

using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Item/Weapon")]
public class WeaponData : ItemData
{
    // Base values for weapon stats
    [field : SerializeField] public float BaseFireRate { get; private set; }
    [field : SerializeField] public float BaseDamage { get; private set; }
    [field: SerializeField] public float FirePower { get; private set; } // Affects the force at which projectiles are shot
    [field: SerializeField] public float AmmoCost { get; private set; }
    [field: SerializeField] public ProjectileController ProjectilePrefab { get; private set; }

}