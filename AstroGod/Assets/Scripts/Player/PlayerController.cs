using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform weaponSlot;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float dashSpeed = 30f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 0.75f;

    public Vector2 moveDir;
    private Vector2 aimDir;
    private bool isDashing = false;
    private bool canDash = true;

    [SerializeField] private InteractSystem interactSystem;
    [SerializeField] private WeaponManager weaponManager;

    private void Start()
    {
        
    }

    private void Update()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        moveDir.Normalize();

        // Rotate firePoint towards cursor
        var cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimDir = (cursorPos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        weaponSlot.eulerAngles = new Vector3(0, 0, angle);
        
        if (canDash && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash());
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

        int? numberInput = GetNumberInput();
        if (numberInput != null)
        {
            SelectWeapon((int)numberInput - 1);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            DropWeapon();
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.MovePosition(rb.position + moveDir * moveSpeed * Time.deltaTime);
        }
        
    }

    private void SelectWeapon(int weaponIndex)
    {
        weaponManager.EquipWeapon(weaponIndex);
    }

    private void Fire()
    {
        //weaponManager.EquippedWeapon.Fire();
        
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
        rb.velocity = moveDir * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private int? GetNumberInput()
    {
        KeyCode[] numberKeys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };
        for (int i = 0; i < numberKeys.Length; i++)
        {
            if (Input.GetKeyDown(numberKeys[i]))
            {
                return i + 1;
            }
        }
        return null;
    }

    private void Interact()
    {
        Interactable obj = interactSystem.Target;
        if (obj == null) return;

        obj.OnInteract();
    }

    private void DropWeapon()
    {
        var weaponToDrop = weaponManager.equippedWeapon;
        if (weaponToDrop == null) return;

        // Spawn the corresponding pickup item
        var weaponPickUp = Instantiate(weaponManager.equippedWeapon.PickUp, transform.position, transform.rotation);
        weaponManager.RemoveWeapon(weaponToDrop);

        Debug.Log($"Dropped {weaponToDrop.name}");

    }
}
