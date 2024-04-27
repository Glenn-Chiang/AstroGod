public class EnemyStats
{
    public readonly Stat maxHealth;
    public readonly Stat moveSpeed;

    public EnemyStats(EnemyData data)
    {
        maxHealth = new(data.MaxHealth.BaseValue, data.MaxHealth.MaxValue);
        moveSpeed = new(data.MoveSpeed.BaseValue, data.MoveSpeed.MaxValue);
    }
}