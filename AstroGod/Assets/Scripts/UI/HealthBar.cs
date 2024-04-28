using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] HealthManager healthManager;
    [SerializeField] private Slider slider;

    private void Update()
    {
        slider.maxValue = healthManager.MaxHealth;
        slider.value = healthManager.Health;
    }
}