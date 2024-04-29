using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private Slider slider;

    private void Update()
    {
        slider.maxValue = healthManager.MaxHealth;
        slider.value = healthManager.Health;
    }
}