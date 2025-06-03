using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [field: SerializeField] public Sprite EndBGSprite { get; private set; }

    [SerializeField] private int _number;

    public static Level CurrentLevel { get; private set; }

    private void Awake()
    {
        if (PlayerPrefs.GetInt("CurrentLevel", 1) == _number)
        {
            CurrentLevel = this;
            return;
        }
    }
}