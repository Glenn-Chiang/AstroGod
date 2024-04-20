public class Weapon : Item<WeaponData>
{
    public float Damage { get; private set; }
    public float FireRate { get; private set; }

    public Weapon(WeaponData data) : base(data)
    {
        Damage = data.BaseDamage;
        FireRate = data.BaseFireRate;
    }
}
