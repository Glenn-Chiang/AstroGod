using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform centre;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float bulletForce = 20f;

    private Vector2 moveDir;
    private Vector2 aimDir;

    void Update()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        moveDir.Normalize();

        // Rotate towards cursor
        var cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimDir = (cursorPos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        centre.eulerAngles = new Vector3(0, 0, angle);
        
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.deltaTime);
        
    }

    void Fire()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(bulletForce * firePoint.right, ForceMode2D.Impulse);
    }
}
