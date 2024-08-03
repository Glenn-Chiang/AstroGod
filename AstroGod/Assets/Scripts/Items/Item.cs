using UnityEngine;

public abstract class Item : ScriptableObject
{
    public abstract ItemType ItemType { get; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField, TextArea] public string Description { get; private set; }
}

public enum ItemType
{
    Weapon,
    Consumeable
}