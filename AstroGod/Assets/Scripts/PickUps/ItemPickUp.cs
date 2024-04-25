using UnityEngine;

public abstract class ItemPickUp : Interactable 
{
    public virtual IItem Item { get; set; }

    public override void OnInteract(InteractSystem interactor)
    {
        if (interactor.TryGetComponent<InventoryManager>(out var inventoryManager))
        {
            if (PickUp(inventoryManager))
            {
                Destroy(gameObject);
            }
        }
    }

    public abstract bool PickUp(InventoryManager inventoryManager);
}

