using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayableObject : MonoBehaviour, IDamageable
{

    //Composition (part of) relationship
    public Health health = new Health();
    

    //Aggregation (has a) relationship
    public Weapons weapon;



    public abstract void Move(Vector2 direction, Vector2 target);


    //overrides
    public virtual void Move(Vector2 direction)
    {
        //Do one thing using direction
    }

    public virtual void Move(Vector2 direction, float speed)
    {
        
    }

    public virtual void Move(float speed)
    {
        //do another thing using speed
    }

    public abstract void Shoot(Vector2 direction, float speed);


    public abstract void Die();

    public abstract void GetDamage(float damage);
    
}
