using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    [SerializeField] private XPManager xpManager;
    [SerializeField] private Slider slider;

    private void Update()
    {
        slider.maxValue = xpManager.xpPerLevel;
        slider.value = xpManager.CurrentLevelXp;
    }
}