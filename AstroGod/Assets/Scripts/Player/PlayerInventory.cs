using UnityEngine;


// Responsible for moving items between the game world and the player inventory
public class PlayerInventory : InventoryManager
{
    public readonly WeaponInventory weaponInventory = new();
    public readonly ArmorInventory armorInventory = new();
    public readonly StackableInventory consumableInventory = new();

    [SerializeField] private RectTransform inventoryMenu;

    private void Update()
    {
        // Player can use number keys to select weapons from weapon inventory
        int numberInput = GetNumberInput();
        if (numberInput != -1)
        {
            weaponInventory.SelectItem(numberInput - 1);
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
    public override bool AddItem(IItemInstance item)
    {
        bool added = false;
        switch (item.Data.ItemType)
        {
            case ItemType.Weapon:
                added = weaponInventory.AddItem((Weapon)item);
                break;
            case ItemType.Armor:
                added = armorInventory.AddItem((Armor)item);
                break;        
            default:
                return false;
        }

        if (added)
        {
            Debug.Log($"Added {item.Data.Name} to {item.Data.ItemType} inventory");
            return true;
        }
        return false;
    }

    public override bool AddItem(ItemData itemData, int amountToAdd)
    {
        return consumableInventory.AddItem(itemData, amountToAdd);
    }

    private void DropWeapon()
    {
        DropItemInstance(weaponInventory);
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