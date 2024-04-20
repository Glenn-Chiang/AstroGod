public class Weapon : Item<WeaponData>
{
    public float damage;
    public float fireRate;

    public Weapon(WeaponData data) : base(data)
    {
        damage = data.baseDamage;
        fireRate = data.baseFireRate;
    }
}
