using UnityEngine;

public class ArmorPickUp : ItemPickUp<ArmorData, Armor>
{
    private void Awake()
    {
        itemInstance = new(data);
    }
}