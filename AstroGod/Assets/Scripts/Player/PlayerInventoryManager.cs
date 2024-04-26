using System.Collections.Generic;
using UnityEngine;


// Responsible for moving items between the game world and the player inventory
public class PlayerInventoryManager : InventoryManager
{
    public readonly InstanceInventory<Weapon> weaponInventory = new(3);
    public readonly InstanceInventory<Armor> armorInventory = new(2);
    public readonly StackableInventory consumableInventory = new(6);

    public override List<IInventory> Inventories => new() { weaponInventory, armorInventory, consumableInventory };
    public override List<StackableInventory> StackableInventories => new() { consumableInventory };

    private int selectedInventoryIndex = 0;
    public override int SelectedInventoryIndex => selectedInventoryIndex;
    public IInventory SelectedInventory => Inventories[selectedInventoryIndex];

    private bool isActive = false; // Determines whether the inventory menu is open, and whether inventory operations can be performed
    public override bool IsActive => isActive;

    private void Update()
    {
        if (isActive)
        {
            // Close if already open
            if (Input.GetKeyDown(KeyCode.I))
            {
                isActive = false;
                selectedInventoryIndex = 0;
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                // Select next inventory
                if (selectedInventoryIndex < Inventories.Count - 1)
                {
                    selectedInventoryIndex++;
                }
                // If we are already at last inventory, go back to first one
                else
                {
                    selectedInventoryIndex = 0;
                }
            }
        } else
        {
            // Open the inventory menu
            if (Input.GetKeyDown(KeyCode.I))
            {
                isActive = true;
            }
        }
        
        // Player can use number keys to select an item from the currently selected inventory
        int selectedItemIndex = GetNumberInput() - 1;
        if (selectedItemIndex != -1)
        {
            SelectedInventory.SelectItem(selectedItemIndex);
        }

        switch (SelectedInventory)
        {
            case InstanceInventory instanceInventory:
                if (Input.GetKeyDown(KeyCode.G))
                {
                    DropItem(instanceInventory);
                }

                break;

            case StackableInventory stackableInventory:
                if (Input.GetKeyDown(KeyCode.G))
                {
                    DropItem(stackableInventory);
                }

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    // Use consumable item
                    var selectedItem = stackableInventory.SelectedItem;
                    selectedItem.Consume(gameObject);
                }

                break; 
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