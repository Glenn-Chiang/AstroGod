using System;
using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Movement movement;

    [SerializeField] private WeaponController weaponController;

    [SerializeField] private float fireInterval = 0.5f;
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
                Attack();
                break;
        }
    }

    protected virtual void Attack() // EnemyAI subclasses can override this to have different attack pattern
    {
        TrackTarget();

        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0)
        {
            weaponController.HandleFire();
            fireTimer = fireInterval;
        }
    }

    private void TrackTarget()
    {
        Vector2 aimDir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        weaponController.transform.eulerAngles = new Vector3(0, 0, angle);
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
