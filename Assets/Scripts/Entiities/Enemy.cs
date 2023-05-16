using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayableObject
{
    //Fields
    private string name;

    [SerializeField]
    private float speed;

    public Health health;

    public Weapon weapon;


    public static int numberOfEnemies;

   protected Transform target;


    private EnemyType enemyType;


    Vector2 targetOsc;

    
    private float amplitude;


    private float frequency;



    protected virtual void Start()
    {
        target = GameObject.FindWithTag("Player").transform;

        amplitude = Random.RandomRange(0, 15);

        frequency = Random.RandomRange(0, 10);

    }

    protected virtual void Update()
    {
        if(target != null)
        {
            Move(target.position,speed);
            
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
  

    //Methods
    ///may need to change parameters
    public override void Move(Vector2 direction, Vector2 target)
    {

    }
    
    public override void Move(Vector2 direction,float speed)
    {

        float xpos = target.position.x;
        float ypos = target.position.y + amplitude * Mathf.Sin(frequency * Time.timeSinceLevelLoad);

        targetOsc = new Vector2(xpos, ypos);

        transform.position = Vector2.MoveTowards(transform.position, targetOsc, speed );
    }

    public override void Move(float Speed)
    {
       

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }




    public override void Shoot(Vector3 direction,float speed)
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

        ///substract damage amount from the current health
        Die();
    }
}
