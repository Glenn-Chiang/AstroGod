using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] private List<ItemPickUp> itemPrefabs;

    public override void OnInteract(GameObject interactor)
    {
        var itemPickUp = SelectItem();
        Instantiate(itemPickUp, transform.position, transform.rotation);
    }

    private ItemPickUp SelectItem()
    {
        // TODO: Randomly select item
        return itemPrefabs[0];
    }
}