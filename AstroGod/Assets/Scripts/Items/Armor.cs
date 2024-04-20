public class Armor : Item<ArmorData>
{
    public float damageResistance;

    public Armor(ArmorData data) : base(data)
    {
        damageResistance = data.damageResistance;
    }
}

