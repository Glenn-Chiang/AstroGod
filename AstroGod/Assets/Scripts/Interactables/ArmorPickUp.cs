public class ArmorPickUp : ItemPickUp<ArmorData, ArmorInstance>
{
    private void Awake()
    {
        instance = new(data);
    }
}