public class WeaponInstance : ItemInstance<WeaponData>
{
    private float damage;
    private float fireRate;

    public WeaponInstance(WeaponData data) : base(data)
    {
        damage = Data.baseDamage;
        fireRate = Data.baseFireRate;
    }
}