using UnityEngine;

public abstract class CharacterData : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public Stat MaxHealth { get; private set; }
    [field: SerializeField] public Stat MoveSpeed { get; private set; }
}