using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "Item/Gun")]
public class GunData : WeaponData
{
    [field: SerializeField] public ProjectileController ProjectilePrefab { get; private set; }
    [field: SerializeField] public int AmmoCost { get; private set; }

}
