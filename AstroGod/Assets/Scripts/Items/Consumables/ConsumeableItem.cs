using UnityEngine;

public abstract class ConsumableItem : ItemData
{
    public override ItemType ItemType => ItemType.Consumeable;
    public override bool Instantiable => false;
    [field: SerializeField] public int StackLimit { get; private set; } // How many of this item the player can own

    public abstract void Consume(GameObject consumer);
}