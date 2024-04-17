using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    public float range = 2.5f; // Max range at which objects can be interacted with
    private List<Interactable> objectsInRange = new(); // List of interactable objects within range

    // The object that the player will interact with when the interact key is pressed
    // This will be the object that is nearest to the player
    public Interactable Target
    {
        get 
        {
            return objectsInRange.OrderBy(obj => obj.distanceFromPlayer).FirstOrDefault();
        }
    }

    // Add object to list of objects that are within range
    public void AddItem(Interactable obj)
    {
        if (!objectsInRange.Contains(obj))
        {
            objectsInRange.Add(obj);
        }
    }

    public void RemoveItem(Interactable obj)
    {
        if (objectsInRange.Contains(obj))
        {
            objectsInRange.Remove(obj);
        }
    }

    public float CalculateDistance(Interactable obj)
    {
        return Vector2.Distance(transform.position, obj.transform.position);
    }
}