using UnityEngine;

public class AmmoPack : Consumable
{ 
    [SerializeField] private int ammoCount;
    public override void Consume(GameObject consumer)
    {
        if (consumer.TryGetComponent<AmmoManager>(out var ammoManager))
        {
            ammoManager.AddAmmo(ammoCount);
        }
    }
}