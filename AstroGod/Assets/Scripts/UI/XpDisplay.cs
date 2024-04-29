using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XpDisplay : MonoBehaviour
{
    [SerializeField] private XPManager xpManager;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text levelDisplay;

    private void Update()
    {
        slider.maxValue = xpManager.xpPerLevel;
        slider.value = xpManager.CurrentLevelXp;
        levelDisplay.text = $"LVL {xpManager.Level}";
    }
}