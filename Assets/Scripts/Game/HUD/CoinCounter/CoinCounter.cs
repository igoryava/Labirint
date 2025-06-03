using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private int _coinsOnLevel;

    private int _coinsLeft;

    public event Action<int> CoinsValueChanged;
    public event Action AllCoinsCollected;

    public static CoinCounter Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    private void Start()
    {
        _coinsLeft = _coinsOnLevel;
        CoinsValueChanged?.Invoke(_coinsLeft);
    }

    public void OnSpawned()
    {
        _coinsOnLevel++;
    }

    public void OnPickuped()
    {
        _coinsLeft--;
        if (_coinsLeft <= 0)
        {
            _coinsLeft = 0;
            AllCoinsCollected?.Invoke();
        }

        CoinsValueChanged?.Invoke(_coinsLeft);
    }
}