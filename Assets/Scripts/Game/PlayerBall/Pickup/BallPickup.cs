using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IPickupable>(out IPickupable pickupable))
        {
            pickupable.Pickup();
        }
    }
}