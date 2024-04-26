using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryMenuController : MonoBehaviour
{
    [SerializeField] private List<RectTransform> inventoryDisplays;
    private int displayedIndex = 0; // Index of currently displayed inventory
    private RectTransform DisplayedInventory => inventoryDisplays[displayedIndex];

    private bool isOpen = false;

    private void Update()
    {
        if (!isOpen)
        {
            if (Input.GetKeyUp(KeyCode.I))
            {
                displayedIndex = 0;
                DisplayedInventory.gameObject.SetActive(true);
                isOpen = true;    
            }
        } else
        {
            if (Input.GetKeyDown (KeyCode.I))
            {
                DisplayedInventory.gameObject.SetActive(false);
                isOpen = false;
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                DisplayedInventory.gameObject.SetActive(false);
                if (displayedIndex < inventoryDisplays.Count - 1)
                {
                    displayedIndex++;
                } else // If we are already at last index, go back to first index
                {
                    displayedIndex = 0;
                }
                DisplayedInventory.gameObject.SetActive(true);
            }
        }
    }
}