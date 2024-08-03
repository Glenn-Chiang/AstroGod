using UnityEngine;

public class HealthPack : Consumable
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