using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class GameWin : MonoBehaviour
{
    [SerializeField] private Image _bg;

    [SerializeField] private GameObject _winCanvas;

    [SerializeField] private CoinCounter _coinCounter;
    [SerializeField] private Collider2D _playerCollider;
    [SerializeField] private Collider2D _outCollider;

    [SerializeField] private GameLose _lose;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void OnEnable()
    {
        _coinCounter.AllCoinsCollected += OnAllCoinsCollected;
    }

    private void OnAllCoinsCollected()
    {
        _coinCounter.AllCoinsCollected -= OnAllCoinsCollected;
        _lose.enabled = false;

        _playerCollider.OnTriggerEnter2DAsObservable().Subscribe(other =>
        {
            if (other == _outCollider)
            {
                Win();
                _disposable.Clear();
            }
        }).AddTo(_disposable);
    }

    private void Win()
    {
        PlayerPrefs.SetInt("CompleatedLevels", PlayerPrefs.GetInt("CompleatedLevels", 1) + 1);
        _bg.sprite = Level.CurrentLevel.EndBGSprite;
        Time.timeScale = 0;
        _winCanvas.SetActive(true);
    }

    private void OnDisable()
    {
        _disposable?.Clear();
        _coinCounter.AllCoinsCollected -= OnAllCoinsCollected;
    }
}