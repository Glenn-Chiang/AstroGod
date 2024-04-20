using UnityEngine;

public abstract class ItemPickUp : Interactable
{
    public abstract ItemData Data { get; }
    public abstract IItem ItemInstance { get; set; }
}

public abstract class ItemPickUp<TData, TItem> : ItemPickUp
    where TData : ItemData
    where TItem : Item<TData>
{
    [SerializeField] protected TData data;
    [SerializeField] protected TItem itemInstance;

    public override ItemData Data => data;
    public override IItem ItemInstance { get => itemInstance; set { itemInstance = (TItem)value; } }

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