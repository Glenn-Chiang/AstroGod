using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] private List<ItemPickUp> itemPrefabs;

    public override void OnInteract(InteractSystem interactSystem)
    {
        var itemPickUp = GetRandomItem();
        Instantiate(itemPickUp, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private ItemPickUp GetRandomItem()
    {
        return RandomUtils.RandomSelect(itemPrefabs);
    }
}