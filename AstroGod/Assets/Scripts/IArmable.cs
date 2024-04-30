public interface IArmable
{
    InstanceInventory<IWeapon> WeaponInventory { get; }
    AmmoManager AmmoManager { get; }
}