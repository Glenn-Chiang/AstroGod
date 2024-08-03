using UnityEngine;

public abstract class WeaponData : Item
{
    public override ItemType ItemType => ItemType.Weapon;
    [field: SerializeField] public int AmmoCost { get; private set; }
    [field : SerializeField] public float FireRate { get; private set; } // Cooldown time interval, in seconds, between each fire
    [field : SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public WeaponController Controller { get; private set; } // Game object representing the item instance when it is visibly held/equipped by the player
}
