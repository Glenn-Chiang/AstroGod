public class Armor : ItemInstance<ArmorData>
{
    public float damageResistance;

    public Armor(ArmorData data) : base(data)
    {
        damageResistance = data.BaseResistance;
    }
}

