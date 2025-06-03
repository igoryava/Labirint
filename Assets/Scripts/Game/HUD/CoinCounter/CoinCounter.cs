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

    private void Start()
    {
        _coinsLeft = _coinsOnLevel;
        CoinsValueChanged?.Invoke(_coinsLeft);
    }
    
    private void Awake()
    {
        Coin.Pickuped += OnPickuped;
        Coin.Spawned += OnSpawned;
    }

    private void OnSpawned()
    {
        _coinsOnLevel++;
    }

    private void OnPickuped()
    {
        _coinsLeft--;
        if (_coinsLeft <= 0)
        {
            _coinsLeft = 0;
            AllCoinsCollected?.Invoke();
        }

        CoinsValueChanged?.Invoke(_coinsLeft);
    }

    // private void OnDisable()
    // {
    //     Coin.Pickuped -= OnPickuped;
    //     Coin.Spawned -= OnSpawned;
    // }
}