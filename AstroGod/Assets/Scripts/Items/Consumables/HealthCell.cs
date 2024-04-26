using UnityEngine;

[CreateAssetMenu(fileName = "HealthCell", menuName = "Consumable/HealthCell")]
public class HealthCell : StackableItem
{
    [SerializeField] private float healAmount;

    public override void Consume(GameObject consumer)
    {
        if (consumer.TryGetComponent<HealthManager>(out var healthManager))
        {
            healthManager.Heal(healAmount);
            Debug.Log($"Healed {consumer.name}");
        }
    }
}