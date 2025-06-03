using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class GameLose : MonoBehaviour
{
    [SerializeField] private Image _bg;

    [SerializeField] private GameObject _loseCanvas;

    [SerializeField] private Collider2D _playerCollider;
    [SerializeField] private Collider2D _outCollider;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void OnEnable()
    {
        _playerCollider.OnTriggerEnter2DAsObservable().Subscribe(other =>
        {
            if (other == _outCollider)
            {
                Lose();
                _disposable.Clear();
            }
        }).AddTo(_disposable);
    }

    private void Lose()
    {
        _bg.sprite = Level.CurrentLevel.EndBGSprite;
        Time.timeScale = 0;
        _loseCanvas.SetActive(true);
    }

    private void OnDisable()
    {
        _disposable?.Clear();
    }
}