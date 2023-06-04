using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject pickupPrefab;

    float x;

    float y;

    [SerializeField]
    float range;

    Vector2 pickupPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator Spawner()
    {
       
        while (true)
        {
            yield return new WaitForSeconds(1f);


            x = Random.Range(-range, range);
            y = Random.Range(-range, range);

            pickupPosition.x = x;
            pickupPosition.y = y;

            Instantiate(pickupPrefab, pickupPosition, Quaternion.identity);
        }
}
}
