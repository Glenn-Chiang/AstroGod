using UnityEngine;

[CreateAssetMenu(fileName = "AmmoCell", menuName = "Consumable/AmmoCell")]
public class AmmoCell : StackableItem
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