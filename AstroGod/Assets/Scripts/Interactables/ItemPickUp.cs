using UnityEngine;

public abstract class ItemPickUp : Interactable
{
    public abstract ItemData Data { get; }
    public abstract ItemInstance Instance { get; set; }
}

public abstract class ItemPickUp<TData, TInstance> : ItemPickUp
    where TData : ItemData
    where TInstance : ItemInstance<TData>
{
    public TData data; // Assign scriptable object in editor
    public TInstance instance; // Initialized by subclass

    public override ItemData Data => data;
    public override ItemInstance Instance => instance;

    public override void OnInteract()
    {
        PickUp();
    }

    private void PickUp()
    {
        if (Player.InventoryManager.AddItem(instance))
        {
            Destroy(gameObject);
        }
    }
}