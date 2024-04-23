using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected PlayerController Player { get; private set; }
    private PlayerInteraction InteractSystem { get; set; }

    private void Start()
    {
        Player = PlayerController.Instance;
        InteractSystem = Player.InteractSystem;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // If player enters collision zone
        if (collider.gameObject == PlayerController.Instance.gameObject)
        {
            InteractSystem.AddObject(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        // If player exits collision zone
        if (collider.gameObject == PlayerController.Instance.gameObject)
        {
            InteractSystem.RemoveObject(this);
        }
    }
    public abstract void OnInteract(GameObject interactor);
    
}