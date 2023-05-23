using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayableObject
{
    // Properties // Fields

    private string name;

    [SerializeField]
    public float speed;

    public Health health;
    public Weapons weapon;

    public static int numberOfEnemies;

    protected Transform target;

    private EnemyType enemyType;

    Vector2 targetOsc;
    [SerializeField]
    private float amplitude;

    [SerializeField]
    private float frequency;


    protected virtual void Start()
    {
        target = GameObject.FindWithTag("Player").transform;

        amplitude = UnityEngine.Random.Range(0, 4);

        frequency = UnityEngine.Random.Range(0, 4);
    }

    protected virtual void Update()
    {
        if(target != null)
        {
            Move(target.position, speed);
            
        }
        else
        {
            Move(speed);
        }
    }

   

    public Enemy()
    {
        AddEnemy();
    }


    // Methods

    //may need to change parameters (override)
    public override void Move(Vector2 direction, Vector2 target)
    {

    }

    public override void Move(Vector2 direcetion, float speed)
    {
        float xpos = target.position.x;
        float ypos = target.position.y + amplitude * Mathf.Sin(frequency * Time.timeSinceLevelLoad);

        targetOsc = new Vector2(xpos, ypos);

        transform.position = Vector2.MoveTowards(transform.position, targetOsc, speed);


        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
    }

    public override void Move(float Speed)
    {
        
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public override void Shoot(Vector2 direction, float speed)
    {

    }

    public virtual void Attack()
    {

    }

    public virtual void Attack(float rate)
    {

    }

    public override void Die()
    {
        
        Destroy(gameObject);
    }

    public void SetEnemyType(EnemyType enemyType)
    {
        this.enemyType = enemyType;
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
        /// subract damage amount from the current health
        Die();
    }

}
