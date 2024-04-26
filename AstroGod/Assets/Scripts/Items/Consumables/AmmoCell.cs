using UnityEngine;

[CreateAssetMenu(fileName = "AmmoCell", menuName = "Consumable/AmmoCell")]
public class AmmoCell : StackableItemData
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