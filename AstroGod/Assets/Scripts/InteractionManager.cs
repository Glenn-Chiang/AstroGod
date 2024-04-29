using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class InteractionManager : MonoBehaviour, INotifyPropertyChanged
{
    // Keep track of interactable objects within range
    private List<Interactable> trackedObjects = new();

    public event PropertyChangedEventHandler PropertyChanged;

    // The object that the player will interact with when the interact key is pressed
    public Interactable Target
    {
        // Target the object that is nearest to the player
        get 
        {
            return trackedObjects.OrderBy(obj => CalculateDistance(obj)).FirstOrDefault();
        }
    }

    public void Interact()
    {
        if (Target != null)
        {
            Target.OnInteract(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // If an entity with an interact system e.g. player or npc enters the collision zone of the interactable object, add the object to the interact system
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

    protected void OnTargetChange()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Target)));
    }

    // Add object to list of objects that are within range
    public void AddObject(Interactable obj)
    {
        if (!trackedObjects.Contains(obj))
        {
            trackedObjects.Add(obj);
            OnTargetChange();
        }
    }

    public void RemoveObject(Interactable obj)
    {
        if (trackedObjects.Contains(obj))
        {
            trackedObjects.Remove(obj);
            OnTargetChange();
        }
    }

    public float CalculateDistance(Interactable obj)
    {
        return Vector2.Distance(transform.position, obj.transform.position);
    }
}