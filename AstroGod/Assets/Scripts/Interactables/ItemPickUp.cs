using UnityEngine;

public abstract class ItemPickUp<TData, TInstance> : Interactable 
    where TData : ItemData
    where TInstance : ItemInstance<TData>
{ 
    public TData Data { get; } // Assign scriptable object in editor
    public TInstance Instance { get; set; } // Initialized by subclass

    public override void OnInteract()
    {
        PickUp();
    }

    private void PickUp()
    {
        if (Player.InventoryManager.AddItem(Instance))
        {
            Destroy(gameObject);
        }
    }
}