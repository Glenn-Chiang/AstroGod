using UnityEngine;

public abstract class ItemPickUp : Interactable 
{ 
    public abstract ItemData ItemData { get; }
    public abstract ItemInstance ItemInstance { get; set; }

    public override void OnInteract()
    {
        PickUp();
    }

    private void PickUp()
    {
        if (Player.InventoryManager.AddItem(ItemInstance))
        {
            Destroy(gameObject);
        }
    }
}