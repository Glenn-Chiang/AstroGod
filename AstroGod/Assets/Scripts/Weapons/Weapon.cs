using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // The pickup item prefab corresponding to this weapon
    public WeaponPickUp PickUp;

    [SerializeField] protected Transform firePoint;
    public abstract void Fire();
}