using UnityEngine;

public abstract class ConsumableItem : StackableItemData
{
    public override ItemType ItemType => ItemType.Consumeable;
    public abstract void Consume(GameObject consumer);
}