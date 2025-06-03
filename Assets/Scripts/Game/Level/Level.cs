using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject _level;

    [field: SerializeField] public Sprite EndBGSprite { get; private set; }

    [SerializeField] private int _number;

    public static Level CurrentLevel { get; private set; }

    private void Awake()
    {
        Debug.Log(PlayerPrefs.GetInt("CurrentLevel", 1));

        if (PlayerPrefs.GetInt("CurrentLevel", 1) == _number)
        {
            CurrentLevel = this;
            _level.SetActive(true);
            return;
        }
    }
}