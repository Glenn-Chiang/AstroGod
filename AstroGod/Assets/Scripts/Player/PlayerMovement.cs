using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform weaponSlot;

    private Stat moveSpeedStat;
    private float MoveSpeed => moveSpeedStat.Value;
    [SerializeField] private float dashSpeed = 30f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 0.75f;

    private Vector2 moveDir;
    public Vector2 MoveDir => moveDir;
    private Vector2 aimDir;
    private bool isDashing = false;
    private bool canDash = true;

    public void Initialize(Stat _moveSpeedStat)
    {
        moveSpeedStat = _moveSpeedStat;
    }

    public void Move(float x, float y)
    {
        moveDir = new Vector2(x, y);
        moveDir.Normalize();
    }

    public void Aim(Vector3 aimPos)
    {
        aimDir = (aimPos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        weaponSlot.eulerAngles = new Vector3(0, 0, angle);

    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.MovePosition(rb.position + moveDir * MoveSpeed * Time.deltaTime);
        }

    }

    public void TryDash()
    {
        if (canDash)
        {
            StartCoroutine(Dash());
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