using UnityEngine;

public class ConsumeableItemPickUp : ItemPickUp
{
    public override void PickUp(GameObject interactor)
    {
        if (interactor.TryGetComponent<InventoryManager>(out var inventoryManager))
        {
            inventoryManager.AddItem(ItemData, 1);
            Destroy(gameObject);
        }
    }

}
