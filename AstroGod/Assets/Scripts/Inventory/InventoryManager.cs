using UnityEngine;

public class InventoryManager
{
    public bool AddItem(ItemInstance item)
    {
        var player = PlayerController.Instance;
        var itemType = item.GetType();

        switch (itemType.Name)
        {
            case nameof(WeaponInstance):
                if (player.WeaponInventory.AddItem((WeaponInstance)item)) 
                {
                    Debug.Log($"Added {item.ItemData.itemName} to weapon inventory");
                    return true;
                }
                return false;
            case nameof(ArmorInstance):
                if (player.ArmorInventory.AddItem((ArmorInstance)item)) 
                {
                    Debug.Log($"Added {item.ItemData.itemName} to armor inventory");
                    return true;
                }
                return false;
            default:
                return false;
        }

    }
}