using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryMenuController : MonoBehaviour
{
    [SerializeField] private List<RectTransform> inventoryDisplays;

    [SerializeField] private InventoryManager inventoryManager;

    private void Update()
    {
        for (int i = 0; i < inventoryDisplays.Count; i++)
        {
            inventoryDisplays[i].gameObject.SetActive(inventoryManager.IsActive && i == inventoryManager.SelectedInventoryIndex);   
        }       
    }
}