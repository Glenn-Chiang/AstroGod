using System;
using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Movement movement;
    
    [SerializeField] private Transform weaponSlot;
    [SerializeField] private Transform firePoint;
    [SerializeField] private ProjectileController projectilePrefab;

    private float fireInterval = 1.5f;
    private float fireTimer;
    private enum State
    {
        Idle,
        Aggro,
        
    }

    private State state = State.Idle;

    private GameObject target; // Currently attacking this target

    private void Start()
    {
        PlayerController.OnPlayerDeath += HandlePlayerDeath;
    }

    private void HandlePlayerDeath(object sender, EventArgs e)
    {
        state = State.Idle;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Idle:
                movement.Roam();
                break;

            case State.Aggro:
                TrackTarget();
                movement.Roam();

                fireTimer -= Time.deltaTime;
                if (fireTimer <= 0)
                {
                    StartCoroutine(FireBurst());
                    fireTimer = fireInterval;
                }

                break;
        }
    }

    private void TrackTarget()
    {
        Vector2 aimDir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        weaponSlot.eulerAngles = new Vector3(0, 0, angle);
    }

    private IEnumerator FireBurst()
    {
        int numberOfShots = 3;
        float shotInterval = 0.1f;
        for (int i = 0; i < numberOfShots; i++)
        {
            Fire();
            yield return new WaitForSeconds(shotInterval);
        }
    }

    private void Fire()
    {
        var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        var projectileRb = projectile.GetComponent<Rigidbody2D>();
        float firePower = 20f;
        projectileRb.AddForce(firePower * firePoint.right, ForceMode2D.Impulse);
        float bulletDamage = 10f;
        projectile.damage = bulletDamage;
    }

    public void OnEnterAggroRadius(GameObject obj)
    {
        state = State.Aggro;
        target = obj;
    }

    public void OnExitAggroRadius()
    {
        state = State.Idle;
        target = null;
    }
}
