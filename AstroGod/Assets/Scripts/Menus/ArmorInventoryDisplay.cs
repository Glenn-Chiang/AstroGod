public class ArmorInventoryDisplay : InstanceInventoryDisplay
{
    private void Start()
    {
        inventory = PlayerController.Instance.InventoryManager.armorInventory;
    }
}
