using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Missing methods:
/// Update(); UpdateSpawnRate(); EndGame();
/// The spawn rate increase feature is not included
/// </summary>
public class GameManager_A : MonoBehaviour
{
    private static GameManager_A instance;
    [SerializeField] private GameObject[] enemyPrefabs;//Converted to array
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] public ScoreManager_A scoreManager;//Change to calll the ScoreManager_A version
    [SerializeField] public UIManager_A uiManager;//Change to calll the UIManager_A version

    //missing variables: "initialSpawnRate", "spawnRateIncrease", "maxSpawnRate", "currentSpawnRate"
    //Added variables: "timeToSpawnEnemy" to be changed to add feature to increase the sapwn rate
    //And isGameActive to control the game over state
    [SerializeField] private Player_A player;
    [SerializeField] private float timeToSpawnEnemy;
    public bool isGameActive = false;

    public static GameManager_A GetInstance()
    {
        return instance;
    }

    private void SetSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        instance = this;
    }

    //------

    private void Awake()
    {
        SetSingleton();
    }

    private void OnEnable()
    {
        GameEvents.GameOver += GameOver;
    }

    private void OnDisable()
    {
        GameEvents.GameOver -= GameOver;
    }

    //Method changed to instantiate a random enemy from the array
    private void CreateEnemy()
    {
        GameObject tempObject = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]);
        tempObject.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
        //add weapon
        //set enemy
    }


    //Does not call the UpdateSpawnRate
    private IEnumerator EnemySpawner()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(timeToSpawnEnemy);
            CreateEnemy();
        }
    }

    public void StartGame()
    {
        scoreManager.ResetScore();
        uiManager.UpdateScore();
        player.gameObject.SetActive(true);
        player.ResetHealth();
        isGameActive = true;
        StartCoroutine(EnemySpawner());
    }

    private void GameOver()
    {
        isGameActive = false;
        StopAllCoroutines();
    }
}
