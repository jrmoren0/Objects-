using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dequeue : MonoBehaviour
{
    [SerializeField]
    GameObject circlePrefab;

    [SerializeField]
    Queue<GameObject> queue = new Queue<GameObject>();


    GameObject tempObject;

    Vector2 lastEnqueuePosition = Vector2.zero;



    // Update is called once per frame
    void Update()
    {

        // Enqueue Object 
        if (Input.GetKeyDown(KeyCode.A))
        {
            tempObject = Instantiate(circlePrefab, transform);
            tempObject.transform.position = new Vector2(lastEnqueuePosition.x + 1, 0);
            tempObject.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            queue.Enqueue(tempObject);
            lastEnqueuePosition = tempObject.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject removedObject = queue.Dequeue();
            Destroy(removedObject);
        }


        }
}
