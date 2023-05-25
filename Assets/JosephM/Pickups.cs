using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    

    public virtual void Start()
    {
        // Destroy the pickup after 10 seconds
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "Player")
        {
            

            Destroy(gameObject);
           
        }
    }

    
}
