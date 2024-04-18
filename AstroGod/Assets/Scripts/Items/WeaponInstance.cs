public class WeaponInstance : ItemInstance
{
    public WeaponData WeaponData { get; }
    public float damage;
    public float fireRate;

    public WeaponInstance(WeaponData data) : base(data)
    {
        WeaponData = data;
        damage = data.baseDamage;
        fireRate = data.baseFireRate;
    }
}