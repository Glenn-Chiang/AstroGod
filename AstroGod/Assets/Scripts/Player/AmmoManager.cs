using System;
using UnityEngine;

[Serializable]
public class AmmoManager
{
    public int MaxAmmo { get; private set; }
    [SerializeField] private int ammoCount;

    public AmmoManager(int maxAmmo)
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