using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        SampleData sample = new SampleData();

        sample.name = "Bob";

        sample.score = 22.1f;

        string data = JsonUtility.ToJson(sample);

        Debug.Log(data);



        string JSON = " { \"name\": \"Marge\", \"score\": 22.1 }";

        SampleData sample2 = JsonUtility.FromJson<SampleData>(JSON);

        Debug.Log("Name: " + sample2.name + " Score: " + sample2.score);
             

    }

   
}
