public class ArmorPickUp : ItemPickUp
{
    public ArmorData ArmorData { get; }
    public ArmorInstance ArmorInstance { get; set; }

    public override ItemData ItemData => ArmorData;
    public override ItemInstance ItemInstance { get => ArmorInstance; set { ArmorInstance = (ArmorInstance)value; } }

    private void Awake()
    {
        ArmorInstance = new(ArmorData);
    }

    protected override void PickUp()
    {
        if (Player.ArmorInventory.AddItem(ArmorInstance))
        {
            // Destroy the pickup only if it was successfully added to the inventory
            Destroy(gameObject);
        }
    }
}