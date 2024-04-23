using UnityEngine;

public abstract class InstancedItemPickUp : ItemPickUp
{
    public IItemInstance itemInstance;

    protected abstract IItemInstance CreateInstance();
    
    private void Awake()
    {    
        itemInstance = CreateInstance();   
    }

    public override void PickUp(GameObject interactor)
    {
        if (interactor.TryGetComponent<InventoryManager>(out var inventoryManager))
        {
            if (inventoryManager.AddItem(itemInstance))
            {
                Destroy(gameObject);
            }
        }
        
    }

}

