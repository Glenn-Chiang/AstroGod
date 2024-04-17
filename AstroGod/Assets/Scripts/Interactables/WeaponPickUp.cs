using UnityEngine;

public class WeaponPickUp : Interactable
{
    // The actual weapon prefab corresponding to this pickup
    [SerializeReference] private Weapon weapon;

    private WeaponManager weaponManager;

    private void Start()
    {
        weaponManager = player.GetComponentInChildren<WeaponManager>();
    }

    // Called when picked up by the player
    public override void OnInteract()
    {
        // Stop targeting this pickup after it is already picked up
        targetingSystem.RemoveItem(this);
        Debug.Log($"Picked up {this.name}");
        weaponManager.AddWeapon(weapon);
        Destroy(gameObject);
    }
}