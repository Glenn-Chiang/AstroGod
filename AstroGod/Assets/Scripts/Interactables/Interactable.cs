using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private InteractSystem interactSystem;

    private void Start()
    {
        interactSystem = PlayerController.Instance.InteractSystem;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // If player enters collision zone
        if (collider.gameObject == PlayerController.Instance.gameObject)
        {
            interactSystem.AddObject(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        // If player exits collision zone
        if (collider.gameObject == PlayerController.Instance.gameObject)
        {
            interactSystem.RemoveObject(this);
        }
    }
    public abstract void OnInteract();

}