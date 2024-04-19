public class WeaponInstance : ItemInstance<WeaponData>
{
    public float damage;
    public float fireRate;

    public WeaponInstance(WeaponData data) : base(data)
    {
        damage = data.baseDamage;
        fireRate = data.baseFireRate;
    }
}