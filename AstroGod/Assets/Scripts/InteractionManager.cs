using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

// Attach this component to entities that should be able to interact with interactable objects
// This component should be attached to a child gameobject e.g. "InteractRadius" of the main entity rather than the main entity itself
// This approach allows the "InteractRadius" gameobject to have its own trigger collider to handle the interactions, separate from the main entity's colliders
public class InteractionManager : MonoBehaviour
{
    // Keep track of interactable objects within range
    private List<Interactable> trackedObjects = new();

    // The object that the interactor will interact with when the interact key is pressed
    public Interactable Target
    {
        // Target the object that is nearest to the interactor
        get 
        {
            return trackedObjects.OrderBy(obj => CalculateDistance(obj)).FirstOrDefault();
        }
    }

    public void Interact()
    {
        if (Target != null)
        {
            // The "interactor" is the parent of this component
            Target.OnInteract(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Interactable>(out var obj))
        {
            AddObject(obj);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Interactable>(out var obj))
        {
            RemoveObject(obj);
        }
    }

    // Add object to list of objects that are within range
    public void AddObject(Interactable obj)
    {
        if (!trackedObjects.Contains(obj))
        {
            trackedObjects.Add(obj);
        }
    }

    public void RemoveObject(Interactable obj)
    {
        if (trackedObjects.Contains(obj))
        {
            trackedObjects.Remove(obj);
        }
    }

    public float CalculateDistance(Interactable obj)
    {
        return Vector2.Distance(transform.position, obj.transform.position);
    }
}