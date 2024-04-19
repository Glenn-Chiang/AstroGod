public class ArmorPickUp : ItemPickUp<ArmorData, ArmorInstance>
{
    private void Awake()
    {
        Instance = new(Data);
    }
}