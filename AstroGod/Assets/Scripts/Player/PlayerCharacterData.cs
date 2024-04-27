using UnityEngine;

[CreateAssetMenu(fileName = "PlayerCharacterData", menuName = "Character/Player")]
public class PlayerCharacterData : CharacterData
{
    [field: SerializeField] public Stat MaxHealth { get; private set; }
    [field: SerializeField] public Stat MoveSpeed { get; private set; }
    [field: SerializeField] public Stat MaxAmmo { get; private set; }
}
