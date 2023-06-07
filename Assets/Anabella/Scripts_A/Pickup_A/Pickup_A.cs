using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_A : MonoBehaviour
{
    public PickupType_A pickupType;

    private void OnEnable()
    {
        GameEvents.GameOver += GameOver;
    }

    private void OnDisable()
    {
        GameEvents.GameOver -= GameOver;
    }

    private void GameOver()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
