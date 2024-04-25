using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class InteractSystem : MonoBehaviour, INotifyPropertyChanged
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Target != null)
        {
            Target.OnInteract(gameObject);
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