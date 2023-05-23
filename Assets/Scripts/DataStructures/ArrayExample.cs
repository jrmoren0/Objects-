using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayExample : MonoBehaviour
{
    [SerializeField]
    private GameObject testPrefab;

    [SerializeField]
    GameObject[] testArray;

    [SerializeField]
    GameObject[] array = new GameObject[2];


    void Start()
    {
        array[0] = Instantiate(testPrefab, transform);
        array[0].transform.position = new Vector2(0, 0);

        array[1] = Instantiate(testPrefab, transform);
        array[1].transform.position = new Vector2(1, 0);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            array[Random.Range(0, array.Length)].GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            Destroy(array[1].gameObject);

            Debug.Log(array[1].name);
        }
    }
}
