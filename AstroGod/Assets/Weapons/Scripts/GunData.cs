using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "Weapon/Gun")]
public class GunData : WeaponData
{
    [field: SerializeField] public ProjectileController ProjectilePrefab { get; private set; }
    [field: SerializeField] public float FirePower { get; private set; } // Affects the force at which projectiles are shot

}
