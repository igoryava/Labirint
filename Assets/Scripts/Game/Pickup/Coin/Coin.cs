using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IPickupable
{
    public static event Action Pickuped;

    public void Pickup()
    {
        Pickuped?.Invoke();
        Destroy(gameObject);
    }
}