using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner_A : MonoBehaviour
{
    [SerializeField]
    private Pickup_A[] pickupPrefab; //changed to be an array and Pickup_A type

    //missing variables to determine position as it is determined by the last position 
    //of the enemy when it dies

    private void OnEnable()
    {
        GameEvents.SpawnPowerup += SpawnPowerUp;
    }

    private void OnDisable()
    {
        GameEvents.SpawnPowerup -= SpawnPowerUp;
    }

    //this method is called on the Enemy script to pass the enemy last position
    private void SpawnPowerUp(Vector2 spawnPos)
    {
        int index = Random.Range(0, pickupPrefab.Length);
        Pickup_A tempObject = Instantiate(pickupPrefab[index]);
        tempObject.transform.position = spawnPos;
    }

}
