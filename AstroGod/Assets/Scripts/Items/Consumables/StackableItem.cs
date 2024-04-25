using UnityEngine;

public abstract class StackableItemData : ItemData
{
    [field: SerializeField] public int StackLimit { get; private set; } // How many of this item the player can own
        
}