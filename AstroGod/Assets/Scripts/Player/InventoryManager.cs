using UnityEngine;

// Responsible for moving items between the game world and the player inventory
public class InventoryManager : MonoBehaviour
{
    private WeaponInventory weaponInventory = new();
    private ArmorInventory armorInventory = new();

    public WeaponInventory WeaponInventory => weaponInventory;
    public ArmorInventory ArmorInventory => armorInventory;

    [SerializeField] private RectTransform inventoryMenu;

    private void Update()
    {
        // Player can use number keys to select weapons from weapon inventory
        int numberInput = GetNumberInput();
        if (numberInput != -1)
        {
            WeaponInventory.SelectItem(numberInput - 1);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryMenu.gameObject.SetActive(!inventoryMenu.gameObject.activeInHierarchy);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            DropWeapon();
        }
    }

    // Determine which inventory to add the item to, based on its type
    public bool AddItem(IItem item)
    {  
        switch (item.Data.ItemType)
        {
            case ItemType.Weapon:
                if (WeaponInventory.AddItem((Weapon)item)) 
                {
                    Debug.Log($"Added {item.Data.Name} to weapon inventory");
                    return true;
                }
                return false;
            case ItemType.Armor:
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

    public bool AddItem(ItemData itemData)
    {
        return true;

    }

    private void DropWeapon()
    {
        DropItem(WeaponInventory);
    }

    // Drop the selected item from the specified inventory into the game world
    // Spawn the corresponding ItemPickUp prefab and transfer the item instance into the prefab
    private void DropItem(IInstanceInventory inventory)
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