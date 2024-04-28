using System;
using UnityEngine;

[Serializable]
public class AmmoManager : MonoBehaviour
{
    private PlayerController player;
    public int MaxAmmo => (int)player.Stats.maxAmmo.Value;
    [SerializeField] private int ammoCount;

    private void Start()
    {
        player = GetComponent<PlayerController>();
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