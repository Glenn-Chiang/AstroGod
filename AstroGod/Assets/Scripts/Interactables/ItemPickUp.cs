using UnityEngine;

public abstract class ItemPickUp<TData, TInstance> : Interactable 
    where TData : ItemData
    where TInstance : ItemInstance<TData>
{
    public TData data; // Assign scriptable object in editor
    public TInstance instance; // Initialized by subclass

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