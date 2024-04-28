using System;
using UnityEngine;

[Serializable]
public class AmmoManager : MonoBehaviour
{
    private PlayerController player;
    public int MaxAmmo => (int)player.Stats.maxAmmo.Value;
    public int AmmoCount { get; private set; }

    private void Start()
    {
        player = GetComponent<PlayerController>();
        AmmoCount = MaxAmmo;
    }

    public bool ConsumeAmmo(int ammoConsumed)
    {
        // Insufficient ammo
        if (AmmoCount < ammoConsumed)
        {
            return false;
        }

        AmmoCount -= ammoConsumed;
        return true;
    }

    public void AddAmmo(int ammoAdded)
    {
        AmmoCount += Mathf.Min(ammoAdded, MaxAmmo - AmmoCount);
    }
}