using UnityEngine;

public class InventoryManager
{
    // Determine which inventory to add the item to, based on its type
    public bool AddItem(IItem item)
    {
        var player = PlayerController.Instance;
        var itemType = item.GetType();

        switch (itemType.Name)
        {
            case nameof(Weapon):
                if (player.WeaponInventory.AddItem((Weapon)item)) 
                {
                    Debug.Log($"Added {item.Data.itemName} to weapon inventory");
                    return true;
                }
                return false;
            case nameof(Armor):
                if (player.ArmorInventory.AddItem((Armor)item)) 
                {
                    Debug.Log($"Added {item.Data.itemName} to armor inventory");
                    return true;
                }
                return false;
            default:
                return false;
        }

    }

    
}