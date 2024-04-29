using UnityEngine;

public abstract class ItemPickUp : Interactable 
{
    public virtual IItem Item { get; set; }

    public override void OnInteract(InteractionManager interactor)
    {
        var inventoryManager = interactor.GetComponentInParent<InventoryManager>();
        if (inventoryManager != null && PickUp(inventoryManager))
        {    
            Destroy(gameObject);   
        }
    }

    public abstract bool PickUp(InventoryManager inventoryManager);
}

