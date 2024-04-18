using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.MovePosition(rb.position + moveDir * moveSpeed * Time.deltaTime);
        }

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

}