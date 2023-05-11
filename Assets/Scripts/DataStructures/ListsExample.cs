using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListsExample : MonoBehaviour
{
    [SerializeField]
    private GameObject circlePrefab;


    [SerializeField]
    List<GameObject> list = new List<GameObject>();
  

    void Start()
    {
        GameObject tempObject;

        tempObject = Instantiate(circlePrefab, transform);
        tempObject.transform.position = new Vector2(0, 0);
        list.Add(tempObject);


        tempObject = Instantiate(circlePrefab, transform);
        tempObject.transform.position = new Vector2(1, 0);
        list.Add(tempObject);

        tempObject = Instantiate(circlePrefab, transform);
        tempObject.transform.position = new Vector2(2, 0);
        list.Add(tempObject);
    }

 
    void Update()
    {   //changes color of random index
        if (Input.GetKeyDown(KeyCode.R))
        {

            list[Random.Range(0, list.Count)].GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        }

        //adds a new object to the list
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject tempObject;
            tempObject = Instantiate(circlePrefab, transform);
            tempObject.transform.position = new Vector2(list[list.Count - 1].transform.position.x + 1, 0);
            list.Add(tempObject);


        }

        //Removes  object at index 2 (third object)
        if (Input.GetKeyDown(KeyCode.X))
        {
            list.RemoveAt(2);
        }


        //Destroys random object from list
        if (Input.GetKeyDown(KeyCode.D))
        {
            Destroy(list[Random.Range(0, list.Count)]);
        }

    }
}
