using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private WeaponInventory weaponInventory;
    [SerializeField] private ArmorInventory armorInventory;

    public WeaponInventory WeaponInventory => weaponInventory;
    public ArmorInventory ArmorInventory => armorInventory;

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
                    Debug.Log($"Added {item.Data.Name} to weapon inventory");
                    Debug.Log(item.Data.Description);
                    return true;
                }
                return false;
            case nameof(Armor):
                if (ArmorInventory.AddItem((Armor)item)) 
                {
                    Debug.Log($"Added {item.Data.Name} to armor inventory");
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

    // Drop the selected item from the specified inventory into the game world
    // Spawn the corresponding ItemPickUp prefab and transfer the item instance into the prefab
    private void DropItem(IInventory inventory)
    {
        var removedItem = inventory.RemoveSelected();
        if (removedItem != null)
        {
            var droppedItem = Instantiate(removedItem.Data.PickUpPrefab, transform.position, transform.rotation);
            droppedItem.ItemInstance = removedItem;
            Debug.Log($"Dropped {removedItem.Data.Name}");
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