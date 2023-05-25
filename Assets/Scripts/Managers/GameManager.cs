using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] public ScoreManager scoreManager;
    [SerializeField] public UIManager UIManager;
    [SerializeField] public Player player;

    private float initialSpawnRate = 1f; // Initial spawn rate in seconds
    private float spawnRateIncrease = 0.1f; // Amount of spawn rate increase per second
    private float maxSpawnRate = 0.2f; // Maximum spawn rate in seconds

    private float currentSpawnRate;

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        SetSingleton();
    }

    void SetSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }

        instance = this;
    }

    void Start()
    {
        currentSpawnRate = initialSpawnRate;
        StartCoroutine(EnemySpawner());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            CreateEnemy();
        }
    }

    void CreateEnemy()
    {
        GameObject tempObject = Instantiate(enemyPrefab);
        tempObject.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
        //add weapon
        //set enemy
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentSpawnRate);
            CreateEnemy();
            UpdateSpawnRate();
        }
    }

    void UpdateSpawnRate()
    {
        currentSpawnRate += spawnRateIncrease;
        if (currentSpawnRate > maxSpawnRate)
        {
            currentSpawnRate = maxSpawnRate;
        }
    }
}