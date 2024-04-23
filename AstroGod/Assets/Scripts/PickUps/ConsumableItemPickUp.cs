using UnityEngine;

public class ConsumeableItemPickUp : ItemPickUp
{
    public int amount = 1;
    public override void PickUp(GameObject interactor)
    {
        if (interactor.TryGetComponent<InventoryManager>(out var inventoryManager))
        {
            if (inventoryManager.AddItem(ItemData, amount))
            {
                Destroy(gameObject);
            }
        }
    }

}
