public class ConsumableInventoryDisplay : StackableInventoryDisplay
{
    private void Start()
    {
        inventory = PlayerController.Instance.InventoryManager.consumableInventory;
    }
}