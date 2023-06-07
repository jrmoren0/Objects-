using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_A : PlayableObject
{
    [SerializeField] private string name;
    //speed changed as protected to be accessed in derived classes
    [SerializeField] protected float speed;

    public Health health;
    //weapon variable changed to call Weapon_A and changed to protected so it does not show on the inspector
    protected Weapon_A weapon;
    public static int numberOfEnemies;
    protected Transform target;
    private EnemyType _enemyType;

    //did not use variables: "Vector2 targetOsc", "float amplitude", "float frequency"

    private void OnEnable()
    {
        GameEvents.GameOver += GameOver;
    }

    private void OnDisable()
    {
        GameEvents.GameOver -= GameOver;
    }

    //method modified as here did not use targetOsc, amplitude or frequency
    //initialized health with default values
    protected virtual void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        health = new Health(10, 0f, 10);
    }

    protected virtual void Update()
    {
        if (target != null)
        {
            Move(target.position, speed);
        }
        else
        {
            Move(speed);
        }
    }

    public Enemy_A()
    {
        AddEnemy();
    }

    //Populated method. Variables use "_"
    public override void Move(Vector2 _direction, Vector2 _target)
    {
        // Get the direction from the game object to the target
        Vector3 direction = _target - _direction;
        direction.z = 0f; // Keep the direction horizontal

        // Rotate the game object to face the target direction
        if (direction != Vector3.zero)
        {
            //added * Quaternion.Euler(0f, 0f, 90f) to correct the rotation so the side facing the target is the one on the X axis
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction) * Quaternion.Euler(0f, 0f, 90f);
        }
    }


    //Changed method as it does not use targetOsc, amplitude or frequency
    public override void Move(Vector2 _direction, float _speed)
    {
        Move(transform.position, target.position);
        transform.position = Vector2.MoveTowards(transform.position, _direction, _speed);
    }

    public override void Move(float _speed)
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }


    public override void Shoot(Vector3 direction, float speed)
    {

    }


    public virtual void Attack()
    {

    }

    public virtual void Attack(float rate)
    {

    }

    //Method changed as here the increment of points is added, only when enemy dies
    //Also includes the spawning of a powerup every five enemy kills
    public override void Die()
    {
        GameManager_A gameManager = GameManager_A.GetInstance();
        SubtractEnemy();
        gameManager.scoreManager.IncrementScore();
        //if is the fifth enemy killed, a powerup will be spawen in the enemy las position
        if (gameManager.scoreManager.GetScore() % 5 == 0)
        {
            GameEvents.SpawnPowerup?.Invoke(transform.position);
        }
        Destroy(gameObject);
    }

    public void SetEnemyType(EnemyType enemyType)
    {
        _enemyType = enemyType;
    }


    public static void AddEnemy()
    {
        numberOfEnemies++;
    }

    public static void SubtractEnemy()
    {
        numberOfEnemies--;
    }


    public override void GetDamage(float damage)
    {
        health.DeductHealth(damage);
        if (health.GetHealth() <= 0)
        {
            Die();
        }
    }

    //New method
    private void GameOver()
    {
        SubtractEnemy();
        Destroy(gameObject);
    }
    
}
