using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] private List<ItemPickUp> itemPrefabs;
    [SerializeField] private GameObject openedChestPrefab; // This will replace the chest after it has been opened i.e. interacted with

    public override void OnInteract(InteractSystem interactSystem)
    {
        var itemPickUp = GetRandomItem();
        Instantiate(itemPickUp, transform.position, transform.rotation);
        Destroy(gameObject);
        Instantiate(openedChestPrefab, transform.position, transform.rotation);
    }

    private ItemPickUp GetRandomItem()
    {
        return RandomUtils.RandomSelect(itemPrefabs);
    }
}