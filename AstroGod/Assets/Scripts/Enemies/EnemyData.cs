using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Character/Enemy")]
public class EnemyData : CharacterData
{
    [field: SerializeField] public float MaxHealth { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float XpReward { get; private set; }
}