using System;
using UnityEngine;

public class LevelUpDisplay : MonoBehaviour
{
    [SerializeField] private RectTransform screen;

    private void Start()
    {
        PlayerController.Instance.XPManager.OnLevelUp += ShowScreen;
    }

    private void ShowScreen(object sender, LevelUpEventArgs e)
    {
        screen.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseScreen()
    {
        screen.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}