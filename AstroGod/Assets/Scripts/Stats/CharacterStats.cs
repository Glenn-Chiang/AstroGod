public abstract class CharacterStats
{
    public readonly Stat maxHealth;
    public readonly Stat moveSpeed;

    public CharacterStats(CharacterData data)
    {
        maxHealth = new(data.MaxHealth.BaseValue, data.MaxHealth.MaxValue);
        moveSpeed = new(data.MoveSpeed.BaseValue, data.MoveSpeed.MaxValue);
    }
}