using System;

public class EnemyDeathEventArgs : EventArgs
{
    public readonly EnemyData enemyData;

    public EnemyDeathEventArgs(EnemyData data)
    {
        enemyData = data;
    }
}