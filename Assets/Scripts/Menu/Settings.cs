using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private int _maxLevels;

    private GameObject _currentPanel;

    private void Start()
    {
        Time.timeScale = 1;
        _currentPanel = _menuCanvas;
    }

    public void OpenClosePanel(GameObject panel)
    {
        _currentPanel.SetActive(false);
        panel.SetActive(true);
        _currentPanel = panel;
    }


    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        int level = PlayerPrefs.GetInt("CompleatedLevels", 1);

        if (level == 1)
        {
            SceneManager.LoadScene("Game");
        }
        else
        {
            if (level >= _maxLevels)
            {
                PlayerPrefs.SetInt("CurrentLevel", 1);
                SceneManager.LoadScene("Game");
                return;
            }

            PlayerPrefs.SetInt("CurrentLevel", level);
            SceneManager.LoadScene("Game");
        }
    }
}