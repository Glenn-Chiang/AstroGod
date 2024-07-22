using UnityEngine;

public class GunPickUp : ItemInstancePickUp
{
    [SerializeField] private GunData data;

    protected override IItemInstance CreateItem()
    {
        return new Gun(data);
    }
}