using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] HealthManager healthManager;
    [SerializeField] private Slider slider;

    private void Start()
    {
        slider.maxValue = healthManager.MaxHealth;
        Debug.Log(healthManager.Health);
        slider.value = healthManager.Health;
    }

    private void Update()
    {
        slider.value = healthManager.Health;
    }
}