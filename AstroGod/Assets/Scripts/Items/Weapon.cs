using UnityEngine;
using System;

[Serializable]
public class Weapon : ItemInstance<WeaponData>
{
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float FireRate { get; private set; }

    public Weapon(WeaponData data) : base(data)
    {
        Damage = data.BaseDamage;
        FireRate = data.BaseFireRate;
    }
}
