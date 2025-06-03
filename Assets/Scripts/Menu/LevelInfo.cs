using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class LevelInfo : MonoBehaviour
{
    [SerializeField] private int _number;

    private Button _button;
    private Image _image;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("CompleatedLevels", 1));

        if (PlayerPrefs.GetInt("CompleatedLevels", 1) >= _number)
        {
            return;
        }

        Lock();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Load);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Load);
    }

    private void Load()
    {
        PlayerPrefs.SetInt("CurrentLevel", _number);
        SceneManager.LoadScene("Game");
    }

    private void Lock()
    {
        _button.interactable = false;
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.g, 10);
    }
}