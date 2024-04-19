public class ArmorInstance : ItemInstance<ArmorData>
{
    public float damageResistance;

    public ArmorInstance(ArmorData data) : base(data)
    {
        damageResistance = data.damageResistance;
    }
}