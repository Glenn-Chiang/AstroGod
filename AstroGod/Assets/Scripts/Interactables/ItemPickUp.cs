using UnityEngine;

public abstract class ItemPickUp<TData, TItem> : Interactable
    where TData : ItemData
    where TItem : IItem
{
    public TData data;
    public TItem itemInstance;

    public override void OnInteract()
    {
        PickUp();
    }

    private void PickUp()
    {
        if (Player.InventoryManager.AddItem(itemInstance))
        {
            Destroy(gameObject);
        }
    }
}