using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = PlayerController.Instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.InteractSystem.Interact();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            player.WeaponEquip.FireWeapon();
        }

        int numberInput = GetNumberInput();
        if (numberInput != -1)
        {
            player.InventoryManager.SelectItem(numberInput - 1);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            player.InventoryManager.DropItemFromInventory();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.InventoryManager.ConsumeItem();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            player.InventoryManager.ToggleInventory();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            player.InventoryManager.SwitchInventory();
        }
    }

    private int GetNumberInput()
    {
        KeyCode[] numberKeys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };
        for (int i = 0; i < numberKeys.Length; i++)
        {
            if (Input.GetKeyDown(numberKeys[i]))
            {
                return i + 1;
            }
        }
        return -1;
    }
}