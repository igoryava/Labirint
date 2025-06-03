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
        Instance = this;
    }

    private void OnEnable()
    {
        Coin.Spawned += OnSpawned;
        Coin.Pickuped += OnPickuped;
    }

    private void OnDisable()
    {
        Coin.Spawned -= OnSpawned;
        Coin.Pickuped -= OnPickuped;
    }

    public void OnSpawned()
    {
        Debug.Log("Coin Spawned");
        _coinsOnLevel++;
        _coinsLeft = _coinsOnLevel;
        CoinsValueChanged?.Invoke(_coinsLeft);
    }

    public void OnPickuped()
    {
        Debug.Log("Coin Pickuped");
        _coinsLeft--;
        if (_coinsLeft <= 0)
        {
            _coinsLeft = 0;
            AllCoinsCollected?.Invoke();
        }

        CoinsValueChanged?.Invoke(_coinsLeft);
    }
}