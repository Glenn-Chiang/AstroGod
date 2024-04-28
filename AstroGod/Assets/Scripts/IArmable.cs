public interface IArmable
{
    InstanceInventory<Weapon> WeaponInventory { get; }
    AmmoManager AmmoManager { get; }
}