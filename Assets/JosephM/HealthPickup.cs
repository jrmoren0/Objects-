using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickups
{ 
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            GameManager.GetInstance().player.AddHealth();

            Destroy(gameObject);

        }

    }
}
