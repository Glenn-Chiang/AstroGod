using UnityEngine;

public class HealthCell : ConsumableItem
{
    [SerializeField] private float healAmount;

    public override void Consume(GameObject consumer)
    {
        if (consumer.TryGetComponent<HealthManager>(out var healthManager))
        {
            healthManager.Heal(healAmount);
        }
    }
}