using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private CoinCounter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _counter.CoinsValueChanged += OnCoinsValueChanged;
    }

    private void OnCoinsValueChanged(int value)
    {
        _text.text = value.ToString();
    }

    private void OnDisable()
    {
        _counter.CoinsValueChanged -= OnCoinsValueChanged;
    }
}