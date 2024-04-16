using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickUpTargeting : MonoBehaviour
{
    public float range = 2.5f; // Max range at which item can be picked up by player
    private List<PickUpItem> itemsInRange = new(); // List of items that are within range

    // The item that the player will pick up when the pick-up key is pressed
    // This will be the item that is nearest to the player
    public PickUpItem Target
    {
        get 
        {
            return itemsInRange.OrderBy(item => item.distanceFromPlayer).FirstOrDefault();
        }
    }

    // Add item to list of items that are within range
    public void AddItem(PickUpItem item)
    {
        if (!itemsInRange.Contains(item))
        {
            itemsInRange.Add(item);
        }
    }

    public void RemoveItem(PickUpItem item)
    {
        if (itemsInRange.Contains(item))
        {
            itemsInRange.Remove(item);
        }
    }

    public float CalculateDistance(PickUpItem item)
    {
        return Vector2.Distance(transform.position, item.transform.position);
    }
}