using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePickup_A : Pickup_A
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        GameEvents.CollectNukePowerup?.Invoke();
    }
}
