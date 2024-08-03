using System;
using Unity.VisualScripting;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerController player;
    private bool isGameOver = false;

    private void Start()
    {
        player = PlayerController.Instance;
        PlayerController.OnPlayerDeath += HandlePlayerDeath;
    }

    private void HandlePlayerDeath(object sender, EventArgs e)
    {
        isGameOver = true;
    }

    private void Update()
    {
        if (isGameOver) return;

        // Interaction
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.InteractSystem.Interact();
        }

        // Firing
        if (Input.GetButtonDown("Fire1"))
        {
            player.WeaponManager.FireWeapon();
        }

        // Switching weapons
        if (GetNumberInput(out int number))
        {
            player.WeaponManager.EquipWeapon(number - 1);
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            player.WeaponManager.SelectNextWeapon();
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            player.WeaponManager.SelectPrevWeapon();
        }

        // Movement
        HandleMovementInputs();
    }

    private void HandleMovementInputs()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        player.Movement.UpdateMovement(x, y);

        var cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player.Movement.Aim(cursorPos);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Movement.TryDash();
        }
    }

    private bool GetNumberInput(out int number)
    {
        KeyCode[] numberKeys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };
        for (int i = 0; i < numberKeys.Length; i++)
        {
            if (Input.GetKeyDown(numberKeys[i]))
            {
                number = i + 1;
                return true;
            }
        }
        number = -1;
        return false;
    }
}