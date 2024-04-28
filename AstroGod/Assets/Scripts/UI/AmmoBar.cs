using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    [SerializeField] AmmoManager ammoManager;
    [SerializeField] private Slider slider;

    private void Update()
    {
        slider.maxValue = ammoManager.MaxAmmo;
        slider.value = ammoManager.AmmoCount;
    }
}