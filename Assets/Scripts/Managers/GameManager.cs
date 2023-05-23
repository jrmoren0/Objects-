using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    /// <summary>
    /// Singleton
    /// </summary>
    private static GameManager instance;


    [SerializeField]
    GameObject enemyPrefab;


    private GameObject tempObject;


    [SerializeField]
    private Transform[] spawnPositions;


    [SerializeField]
    public ScoreManager scoreManager;

    [SerializeField]
    public UIManager UIManager;

    [SerializeField]
    public Player player;


    private float seconds;

    public static GameManager GetInstance()
    {
        return instance;
    }


    void SetSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }

        instance = this;

    }
    //-------


    private void Awake()
    {
        SetSingleton();
    }



    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(EnemySpawner());
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            CreateEnemy();
        }

        
    }


    void CreateEnemy()
    {
        tempObject = Instantiate(enemyPrefab);
        tempObject.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
        //add weapon
        //set enemy
    }

    IEnumerator EnemySpawner() {

        while (true)
        {
            yield return new WaitForSeconds(1f);
            CreateEnemy();
        }

    }
}
