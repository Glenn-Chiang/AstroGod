using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public WeaponInventory WeaponInventory { get; } = new();
    public ArmorInventory ArmorInventory { get; } = new();

    private void Update()
    {
        int numberInput = GetNumberInput();
        if (numberInput != -1)
        {
            WeaponInventory.SelectItem(numberInput - 1);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            DropWeapon();
        }
    }

    // Determine which inventory to add the item to, based on its type
    public bool AddItem(IItem item)
    {
        var player = PlayerController.Instance;
        var itemType = item.GetType();

        switch (itemType.Name)
        {
            case nameof(Weapon):
                if (WeaponInventory.AddItem((Weapon)item)) 
                {
                    Debug.Log($"Added {item.Data.itemName} to weapon inventory");
                    return true;
                }
                return false;
            case nameof(Armor):
                if (ArmorInventory.AddItem((Armor)item)) 
                {
                    Debug.Log($"Added {item.Data.itemName} to armor inventory");
                    return true;
                }
                return false;
            default:
                return false;
        }

    }

    private void DropWeapon()
    {
        DropItem(WeaponInventory);
    }

    private void DropItem(IInventory inventory)
    {
        var removedItem = inventory.RemoveSelected();
        if (removedItem != null)
        {
            var droppedItem = Instantiate(removedItem.Data.pickUpPrefab, transform.position, transform.rotation);
            droppedItem.ItemInstance = removedItem;
            Debug.Log($"Dropped {removedItem.Data.itemName}");
        }
    }

    private int GetNumberInput()
    {
        KeyCode[] numberKeys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };
        for (int i = 0; i < numberKeys.Length; i++)
        {
            if (Input.GetKeyDown(numberKeys[i]))
            {
                return i + 1;
            }
        }
        return -1;
    }
}