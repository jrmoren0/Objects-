using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject machineGunPrefab;
    [SerializeField]
    GameObject missileEnemyPrefab;

    private GameObject tempObject;
    private GameObject machineGun;
    private GameObject missileLauncher;

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
        if(instance != null && instance != this)
        {
            Destroy(this);
        }

        instance = this;
    }

    private void Awake()
    {
        SetSingleton();
    }

    private void Start()
    {
        //seconds = 0;
        StartCoroutine(EnemySpawner());
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            CreateEnemy();
        }

        
    }

    void CreateEnemy()
    {
        tempObject = Instantiate(enemyPrefab);
        tempObject.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
        machineGun = Instantiate(machineGunPrefab);
        machineGun.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
        missileLauncher = Instantiate(missileEnemyPrefab);
        missileLauncher.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;

        //add weapon
        //set enemy
    }

    IEnumerator EnemySpawner()
    {
        while(true)
        {
            yield return new WaitForSeconds(6.0f);
            CreateEnemy();
        }
    }

    
}
