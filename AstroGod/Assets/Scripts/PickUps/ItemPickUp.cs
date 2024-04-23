using UnityEngine;

public abstract class ItemPickUp : Interactable
{
    [field: SerializeField] public virtual ItemData ItemData { get; private set; }

    public override void OnInteract(GameObject interactor)
    {
        PickUp(interactor);
    }

    public abstract void PickUp(GameObject interactor);
}
