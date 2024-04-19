using UnityEngine;

public class WeaponPickUp : ItemPickUp<WeaponData, WeaponInstance>
{
    private void Awake()
    {
        instance = new(data);
    }
}