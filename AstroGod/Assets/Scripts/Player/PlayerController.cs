using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform centre;
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
        //Instantiate(weaponManager.EquippedWeapon, weaponSlot.position, weaponSlot.rotation);
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
        centre.eulerAngles = new Vector3(0, 0, angle);
        
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

    private void Interact()
    {
        Interactable obj = interactSystem.Target;
        if (obj == null) return;

        obj.OnInteract();
    }

    private void DropWeapon()
    {
        var weaponToDrop = weaponManager.EquippedWeapon;
        if (weaponToDrop == null) return;

        // Spawn the corresponding pickup item
        var weaponPickUp = Instantiate(weaponManager.EquippedWeapon.PickUp, transform.position, transform.rotation);
        weaponManager.RemoveWeapon(weaponToDrop);

        Debug.Log($"Dropped {weaponToDrop.name}");

    }
}
