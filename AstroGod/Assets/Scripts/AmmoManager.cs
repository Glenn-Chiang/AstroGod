using System;
using UnityEngine;

[Serializable]
public class AmmoManager : ResourceManager
{
    private PlayerController player;
    public int MaxAmmo => (int)player.Stats.maxAmmo.Value;
    public float AmmoCount { get; private set; }

    public override float MaxValue => MaxAmmo;
    public override float Value => AmmoCount;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        AmmoCount = MaxAmmo;
    }

    public bool ConsumeAmmo(float ammoConsumed)
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