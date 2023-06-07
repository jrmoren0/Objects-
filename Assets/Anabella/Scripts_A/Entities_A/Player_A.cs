using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Does not include the AddHealth method
/// </summary>
public class Player_A : PlayableObject
{
    private string name;
    public float speed;
    private Weapon_A weapon_A; //added to not change PlayableObject script

    [SerializeField] private Camera cam;
    [SerializeField] private float timeToDie;

    private Rigidbody2D playerRigidBody;

    [SerializeField] private float weaponDamage;
    [SerializeField] private float weaponSpeed;
    [SerializeField] private Bullet_A bulletPrefab;//updated to call Bullet_A
    //Does not contain healthUpdate event 

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        health = new Health(100, .5f, 100);
        //different way to update health in UI
        GameManager_A.GetInstance().uiManager.UpdateHealth(health.GetHealth());
        //Set player weapon
        weapon_A = new Weapon_A("Player Weapon", weaponDamage, weaponSpeed);
    }

    private void Update()//added method to regenerate health
    {
        if (GameManager_A.GetInstance().isGameActive)
        {
            health.RegenHealth();
            GameManager_A.GetInstance().uiManager.UpdateHealth(health.GetHealth());
        }
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        playerRigidBody.velocity = direction * speed * Time.deltaTime;

        Vector3 playerScreenPosition = cam.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPosition.x;
        target.y -= playerScreenPosition.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void Shoot(Vector3 direction, float speed)
    {
        weapon_A.Shoot(bulletPrefab, this, "Enemy", timeToDie);
    }

    //Changed method to end game, stop player's movement and call the GameOverUI method from the UIManager
    public override void Die()
    {
        playerRigidBody.velocity = Vector3.zero;
        playerRigidBody.angularDrag = 0;
        GameEvents.GameOver();
    }


    //Other way to deduct health as not using event
    public override void GetDamage(float damage)
    {
        health.DeductHealth(damage);
        GameManager_A.GetInstance().uiManager.UpdateHealth(health.GetHealth());
        if (health.GetHealth() <= 0)
        {
            Die();
        }
    }

    public void ResetHealth()
    {
        health = new Health(100, .5f, 100);
        //different way to update health in UI
        GameManager_A.GetInstance().uiManager.UpdateHealth(health.GetHealth());
    }

}
