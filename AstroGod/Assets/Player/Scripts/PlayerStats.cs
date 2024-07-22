public class PlayerStats : CharacterStats
{   
    public readonly Stat maxAmmo;
 
    public PlayerStats(PlayerCharacterData data) : base(data)
    {
        maxAmmo = new(data.MaxAmmo.BaseValue, data.MaxAmmo.MaxValue);
    }
}