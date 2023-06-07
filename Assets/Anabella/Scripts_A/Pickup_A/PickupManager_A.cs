using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager_A : MonoBehaviour
{
    private List<Enemy_A> enemyList;
    private List<Pickup_A> pickupList;

    private void OnEnable()
    {
        GameEvents.ActivateNukePowerUp += ActivateNukePowerup;
    }

    private void OnDisable()
    {
        GameEvents.ActivateNukePowerUp -= ActivateNukePowerup;
    }

    private void ActivateNukePowerup()//event called on PlayerInput script
    {

        enemyList = new List<Enemy_A>();
        Enemy_A[] activeEnemies = FindObjectsOfType<Enemy_A>();
        enemyList.AddRange(activeEnemies);

        if (enemyList.Count > 0)
        {
            foreach (Enemy_A enemy in enemyList)
            {
                enemy.Die();
            }
            enemyList.Clear();
        }

        pickupList = new List<Pickup_A>();
        Pickup_A[] activePickups = FindObjectsOfType<Pickup_A>();
        pickupList.AddRange(activePickups);

        if (pickupList.Count > 0)
        {
            foreach (Pickup_A pickup in pickupList)
            {
                Destroy(pickup.gameObject);
            }
            pickupList.Clear();
        }


    }
}
