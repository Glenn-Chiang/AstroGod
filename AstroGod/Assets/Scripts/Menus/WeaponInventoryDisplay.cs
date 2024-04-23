public class WeaponInventoryDisplay : InstanceInventoryDisplay
{
    private void Start()
    {
        inventory = PlayerController.Instance.InventoryManager.weaponInventory;       
    }
}
