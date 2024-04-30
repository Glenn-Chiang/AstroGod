using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private Slider slider;

    private void Update()
    {
        slider.maxValue = resourceManager.MaxValue;
        slider.value = resourceManager.Value;
    }
}