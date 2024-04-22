using UnityEngine;

public class AmmoCell : ConsumableItem
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