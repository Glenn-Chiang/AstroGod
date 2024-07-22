using System.Collections.Generic;
using UnityEngine;


// Responsible for moving items between the game world and the player inventory
public class PlayerInventoryManager : InventoryManager
{
    public readonly InstanceInventory<IWeapon> weaponInventory = new(3);
    public readonly InstanceInventory<Armor> armorInventory = new(2);
    public readonly StackableInventory consumableInventory = new(6);

    public override List<IInventory> Inventories => new() { weaponInventory, armorInventory, consumableInventory };
    public override List<StackableInventory> StackableInventories => new() { consumableInventory };

    private int selectedInventoryIndex = 0;
    public override int SelectedInventoryIndex => selectedInventoryIndex;
    public IInventory SelectedInventory => Inventories[selectedInventoryIndex];

    private bool isActive = false; // Determines whether the inventory menu is open, and whether inventory operations can be performed
    public override bool IsActive => isActive;

    public void SwitchInventory()
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

    public void ToggleInventory()
    {
        isActive = !isActive;
        selectedInventoryIndex = 0;
    }

    public void DropItemFromInventory()
    {
        switch (SelectedInventory)
        {
            case InstanceInventory instanceInventory:
                DropItem(instanceInventory);
                break;

            case StackableInventory stackableInventory:    
                DropItem(stackableInventory);
                break;
        }
    }

    public void ConsumeItem()
    {
        consumableInventory.ConsumeSelected(gameObject);
    }

    public void SelectItem(int index)
    {
        SelectedInventory.SelectItem(index);
    }

    public override bool AddItemInstance(IItemInstance itemInstance)
    {
        bool added = false;

        switch(itemInstance)
        {
            case IWeapon weapon:
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
            Debug.Log($"Added {itemInstance.Data.Name} to player inventory");
            return true;
        }
        
        return false;
    }

    public override ItemStack AddItemStack(ItemStack itemStack) // Returns the leftover (if any) of the stack to be added, if the stack limit is exceeded
    {
        return consumableInventory.AddItem(itemStack);
    }

  
}