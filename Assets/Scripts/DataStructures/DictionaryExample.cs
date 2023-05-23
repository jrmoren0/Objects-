using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DictionaryExample : MonoBehaviour
{

    [SerializeField]
    private TMP_Text txtTri, txtSqr, txtCrc;


    [SerializeField]
    Dictionary<string, int> dictionary = new Dictionary<string, int>();



    // Start is called before the first frame update
    void Start()
    {
        dictionary.Add("Triangle", 0);
        dictionary.Add("Square", 0);
        dictionary.Add("Circle", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (dictionary.ContainsKey("Triangle"))
            {
                dictionary["Triangle"]++;
                txtTri.text = dictionary["Triangle"].ToString();
            }
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            if (dictionary.ContainsKey("Square"))
            {
                dictionary["Square"]++;
                txtSqr.text = dictionary["Square"].ToString();
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (dictionary.ContainsKey("Circle"))
            {
                dictionary["Circle"]++;
                txtCrc.text = dictionary["Circle"].ToString();
            }
        }


    }
}
