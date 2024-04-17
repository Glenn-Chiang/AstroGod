using UnityEngine;

public class WeaponPickUp : Interactable
{
    // The weapon prefab corresponding to this pickup
    [SerializeReference] public Weapon weapon;

    private WeaponManager weaponManager;

    private void Start()
    {
        weaponManager = player.GetComponentInChildren<WeaponManager>();
    }

    // Called when picked up by the player
    public override void OnInteract()
    {
        weaponManager.AddWeapon(weapon, out bool ableToAdd);
        if (ableToAdd)
        {
            targetingSystem.RemoveItem(this);
            Destroy(gameObject);
        }
    }
}