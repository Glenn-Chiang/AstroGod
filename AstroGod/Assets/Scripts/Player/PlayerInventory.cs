using UnityEngine;


// Responsible for moving items between the game world and the player inventory
public class PlayerInventory : InventoryManager
{
    public WeaponInventory WeaponInventory { get; private set; }
    public ArmorInventory ArmorInventory { get; private set; }
    public StackableInventory StackableInventory { get; private set; }

    [SerializeField] private RectTransform inventoryMenu;

    private void Awake()
    {
        WeaponInventory = new();
        ArmorInventory = new();
        StackableInventory = new();
    }

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
    public override bool AddItem(IItemInstance item)
    {
        bool added = false;
        switch (item.Data.ItemType)
        {
            case ItemType.Weapon:
                added = WeaponInventory.AddItem((Weapon)item);
                break;
            case ItemType.Armor:
                added = ArmorInventory.AddItem((Armor)item);
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
        return StackableInventory.AddItem(itemData, amountToAdd);
    }

    private void DropWeapon()
    {
        DropItemInstance(WeaponInventory);
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