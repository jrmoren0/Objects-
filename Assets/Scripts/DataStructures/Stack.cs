using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public GameObject circlePrefab;


    public Stack<GameObject> stack = new Stack<GameObject>();

    GameObject tempObject;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            tempObject = Instantiate(circlePrefab, transform);
            tempObject.transform.position = new Vector2(0, stack.Count); //Calculate position based on stack count

          
            tempObject.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            stack.Push(tempObject);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject removedObject = stack.Pop();
            Destroy(removedObject);

        } 
    }
}
