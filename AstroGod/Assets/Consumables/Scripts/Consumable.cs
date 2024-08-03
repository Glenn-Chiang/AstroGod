using UnityEngine;

public abstract class Consumable : Interactable
{
    public override void OnInteract(GameObject interactor)
    {
        Consume(interactor);
        Destroy(gameObject);
    }
    public abstract void Consume(GameObject consumer);
}