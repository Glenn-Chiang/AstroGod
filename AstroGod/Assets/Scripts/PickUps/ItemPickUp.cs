using UnityEngine;

public abstract class ItemPickUp : Interactable
{
    [field: SerializeField] protected virtual ItemData ItemData { get; }

    public IItem item; // ItemStack or ItemInstance

    protected abstract IItem CreateItem();

    private void Awake()
    {
        item = CreateItem();
    }

    public override void OnInteract()
    {
        
    }
}

