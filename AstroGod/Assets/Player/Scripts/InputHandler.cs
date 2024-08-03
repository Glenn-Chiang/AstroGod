using System;
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            player.InteractSystem.Interact();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            player.WeaponEquip.FireWeapon();
        }

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