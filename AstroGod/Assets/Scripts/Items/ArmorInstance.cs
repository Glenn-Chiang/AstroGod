public class ArmorInstance : ItemInstance
{
    public ArmorData ArmorData { get; }
    public float damageResistance;

    public ArmorInstance(ArmorData data) : base(data)
    {
        ArmorData = data;
        damageResistance = data.damageResistance;
    }
}