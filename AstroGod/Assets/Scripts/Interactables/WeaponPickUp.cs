using UnityEngine;

public class WeaponPickUp : ItemPickUp<WeaponData, Weapon>
{
    private void Awake()
    {
        itemInstance = new(data);
        Debug.Log($"{itemInstance.Data.itemName}");
    }
}