public class ArmorPickUp : ItemPickUp
{
    public ArmorData ArmorData { get; }
    public ArmorInstance ArmorInstance { get; set; }

    public override ItemData ItemData => ArmorData;
    public override ItemInstance ItemInstance { get => ArmorInstance; set { ArmorInstance = (ArmorInstance)value; } }

    private void Start()
    {
        ArmorInstance = new(ArmorData);
    }
}