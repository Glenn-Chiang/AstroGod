public class WeaponInstance : ItemInstance
{
    public WeaponData WeaponData { get; }
    private float damage;
    private float fireRate;

    public WeaponInstance(WeaponData data) : base(data)
    {
        WeaponData = data;
        damage = data.baseDamage;
        fireRate = data.baseFireRate;
    }
}