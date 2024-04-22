using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "Character")]
public class CharacterStats : ScriptableObject
{
    [field: SerializeField] public Stat MaxHealth { get; private set; }
    [field: SerializeField] public Stat MaxAmmo { get; private set; }
    [field: SerializeField] public Stat MoveSpeed { get; private set; }
}
