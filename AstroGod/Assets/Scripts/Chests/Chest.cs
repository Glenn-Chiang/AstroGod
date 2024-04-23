using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] private List<InstancedItemPickUp> itemPrefabs;

    public override void OnInteract(GameObject interactor)
    {
        
    }
}