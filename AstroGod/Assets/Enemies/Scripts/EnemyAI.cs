using System;
using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private RoamingMovement movement;

    [SerializeField] private WeaponManager weaponManager;
    private WeaponController EquippedWeapon => weaponManager.EquippedWeapon;

    [SerializeField] private float fireInterval = 0.8f;
    private float fireTimer;
     
    [SerializeField] private float minDistance = 2;

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

                if (Vector2.Distance(transform.position, target.transform.position) > minDistance)
                {
                    movement.MoveTowards(target.transform.position);
                }

                fireTimer -= Time.deltaTime;
                if (fireTimer <= 0)
                {
                    EquippedWeapon.HandleFire();
                    fireTimer = fireInterval;
                }
                break;
        }
    }

    private void TrackTarget()
    {
        Vector2 aimDir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        EquippedWeapon.transform.eulerAngles = new Vector3(0, 0, angle);
    }

    public void EnterAggro(GameObject obj)
    {
        state = State.Aggro;
        target = obj;
    }

    public void ExitAggro()
    {
        state = State.Idle;
        target = null;
    }
}
