using System;
using UnityEngine;

[Serializable]
public class AmmoManager : MonoBehaviour
{
    public int MaxAmmo { get; private set; }
    [SerializeField] private int ammoCount;

    public void Initialize(int maxAmmo)
    {
        MaxAmmo = maxAmmo;
        ammoCount = MaxAmmo;
    }

    public bool ConsumeAmmo(int ammoConsumed)
    {
        // Insufficient ammo
        if (ammoCount < ammoConsumed)
        {
            return false;
        }

        ammoCount -= ammoConsumed;
        return true;
    }

    public void AddAmmo(int ammoAdded)
    {
        ammoCount += Mathf.Min(ammoAdded, MaxAmmo - ammoCount);
    }
}