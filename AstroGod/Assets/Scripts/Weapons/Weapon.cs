using UnityEngine;
using System;

public interface IWeapon : IItemInstance
{
    float Damage { get; }
    float FireRate { get; }

}

[Serializable]
public abstract class Weapon<T> : ItemInstance<T>, IWeapon where T : WeaponData
{
    public float Damage { get; private set; }
    public float FireRate { get; private set; }


    public Weapon(T data) : base(data)
    {
        Damage = data.BaseDamage;
        FireRate = data.BaseFireRate;
    }
}
