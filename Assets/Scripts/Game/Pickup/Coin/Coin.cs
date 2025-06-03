using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IPickupable
{
    private void Start()
    {
        CoinCounter.Instance.OnSpawned();
    }

    public void Pickup()
    {
        CoinCounter.Instance.OnPickuped();
        Destroy(gameObject);
    }
}