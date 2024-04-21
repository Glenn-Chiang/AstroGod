using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public abstract ItemType ItemType { get; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField, TextArea] public string Description { get; private set; }

    [field : SerializeField] public ItemPickUp PickUpPrefab { get; private set; }
    [field : SerializeField] public GameObject ModelPrefab { get; private set; } // Game object representing the item instance when it is visibly held/equipped by the player
}

public enum ItemType
{
    Weapon,
    Armor
}