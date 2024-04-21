using UnityEngine;

public abstract class ItemPickUp : Interactable
{
    protected abstract ItemData ItemData { get; }
    public IItem itemInstance;

    protected abstract IItem CreateItem();

    private void Awake()
    {
        itemInstance = CreateItem();
    }

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