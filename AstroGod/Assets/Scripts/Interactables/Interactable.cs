using System;
using System.ComponentModel;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private InteractSystem interactSystem;

    [SerializeField] private GameObject interactPrompt;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // If player enters collision zone
        if (collider.TryGetComponent<InteractSystem>(out interactSystem))
        {
            // Once the object is being tracked by the player, listen for changes to the Target property
            interactSystem.PropertyChanged += HandleInteractUpdate;
            interactSystem.AddObject(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        // If player exits collision zone
        if (collider.TryGetComponent<InteractSystem>(out interactSystem))
        {
            interactSystem.RemoveObject(this);
            // Once the object is out of range, stop listening for changes to the interact system's Target property
            interactSystem.PropertyChanged -= HandleInteractUpdate;
        }
    }

    private void HandleInteractUpdate(object sender, PropertyChangedEventArgs e)
    {
        // Listen for changes to the Target property
        if (e.PropertyName != nameof(interactSystem.Target)) return;
        // Show or hide interact prompt if this object is being targeted by the player
        Debug.Log($"{this.name} is targeted: {interactSystem.Target == this}");
        interactPrompt.SetActive(interactSystem.Target == this);
    }

    public abstract void OnInteract();

}