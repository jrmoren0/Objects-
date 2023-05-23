using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : PlayableObject
{

    // Properties

    private string name;
    public float speed;

    [SerializeField]
    private Camera cam;

    private Rigidbody2D playerRigidBody;

    [SerializeField]
    private float weaponDamage;

    [SerializeField]
    private float weaponSpeed;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float timeToDie;

    private Health health;

    public Action<float> healthUpdate;



    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();

        health = new Health(100, .5f, 50);
        healthUpdate?.Invoke(health.GetHealth());

        Debug.Log(health.GetHealth());

        //Set Player Weapon
        weapon = new Weapons("Player Weapon", weaponDamage, weaponSpeed);
    }

    // Methods
    public override void Move(Vector2 direction, Vector2 target)
    {
        playerRigidBody.velocity = direction * speed * Time.deltaTime;

        Vector3 playerScreenPosition = cam.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPosition.x;
        target.y -= playerScreenPosition.y;


        //used fancy math
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
       
    }

    public override void Shoot(Vector2 direction, float speed)
    {
        weapon.Shoot(bulletPrefab, this, "Enemy", timeToDie);
    }

// this runs when player dies

    public override void Die()
    {
        Debug.Log("Player Died");

        Destroy(gameObject);
    }

    

    public override void GetDamage(float damage)
    {
        health.DeductHealth(damage);

        healthUpdate?.Invoke(health.GetHealth());

        if(health.GetHealth() <=0)
        {
            Die();
        }
    }
}
