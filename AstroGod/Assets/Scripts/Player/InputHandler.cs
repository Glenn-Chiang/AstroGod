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
        if (Input.GetButtonDown("Fire1"))
        {
            player.WeaponEquip.FireWeapon();
        }
    }
}