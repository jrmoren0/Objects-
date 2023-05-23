using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONExample : MonoBehaviour
{

    private void Start()
    {


        SampleData sample = new SampleData();

        sample.name = "Bob";

        sample.score = 22.1f;

        string data = JsonUtility.ToJson(sample);

        Debug.Log(data);

    }



        
}
