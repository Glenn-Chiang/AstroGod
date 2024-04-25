using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // If an entity with an interact system e.g. player or npc enters the collision zone of the interactable object, add the object to the interact system
        if (collider.TryGetComponent<InteractSystem>(out var interactSystem))
        {
            interactSystem.AddObject(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent<InteractSystem>(out var interactSystem))
        {
            interactSystem.RemoveObject(this);
        }
    }
    public abstract void OnInteract(InteractSystem interactor);
}

// InteractResponse can be subclassed by Interactables to return specific data
public class InteractResponse
{

}