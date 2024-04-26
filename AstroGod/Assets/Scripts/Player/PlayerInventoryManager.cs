using System.Collections.Generic;
using UnityEngine;


// Responsible for moving items between the game world and the player inventory
public class PlayerInventoryManager : InventoryManager
{
    public readonly InstanceInventory<Weapon> weaponInventory = new(3);
    public readonly InstanceInventory<Armor> armorInventory = new(2);
    public readonly StackableInventory consumableInventory = new(6);

    public override List<IInventory> InstanceInventories => new() { weaponInventory, armorInventory };
    public override List<StackableInventory> StackableInventories => new() { consumableInventory };

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
            DropItemInstance(weaponInventory);
        }
    }

    public override bool AddItemInstance(ItemInstance itemInstance)
    {
        bool added = false;

        switch(itemInstance)
        {
            case Weapon weapon:
                added = weaponInventory.AddItem(weapon);
                break;
            case Armor armor:
                added = armorInventory.AddItem(armor);
                break;
            default:
                return false;
        }

        if (added)
        {
            Debug.Log($"Added {itemInstance.ItemData.Name} to player inventory");
            return true;
        }
        
        return false;
    }

    public override ItemStack AddItemStack(ItemStack itemStack) // Returns the leftover (if any) of the stack to be added, if the stack limit is exceeded
    {
        return consumableInventory.AddItem(itemStack);
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