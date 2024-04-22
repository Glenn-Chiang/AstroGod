using UnityEngine;

public class ItemPickUp : Interactable
{
    public override void OnInteract()
    {

    }
}

public class ConsumeableItemPickUp : ItemPickUp
{

}

public class InstancedItemPickUp : ItemPickUp
{
    public virtual ItemData ItemData { get; }
    public IItem ItemInstance 
    { 
        get;
        set;

    }

    protected virtual IItem CreateInstance()
    {
        return null;
    }

    private void Awake()
    {
        if (ItemData.Instantiable)
        {
            ItemInstance = CreateInstance();
        }
    }

    public override void OnInteract()
    {
        bool pickedUp;

        if (ItemData.Instantiable)
        {
            pickedUp = Player.InventoryManager.AddItem(ItemInstance);
        } else
        {
            pickedUp = Player.InventoryManager.AddItem(ItemData);
        }

        if (pickedUp)
        {
            Destroy(gameObject);
        }
        
    }

}

