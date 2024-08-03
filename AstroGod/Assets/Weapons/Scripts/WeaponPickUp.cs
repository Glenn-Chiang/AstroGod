using UnityEngine;

public class WeaponPickUp : Interactable 
{
    [SerializeField] private WeaponData weapon;

    public override void OnInteract(GameObject interactor)
    {
        if (TryGetComponent<WeaponManager>(out var weaponManager) && weaponManager.AddWeapon(weapon))
        {
            Destroy(gameObject);   
        }
    }
}

