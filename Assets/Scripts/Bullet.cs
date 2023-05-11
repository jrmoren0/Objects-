using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float speed;


   

    public void SetBullet(float _damage,float _speed)
    {
        this.damage = _damage;

        this.speed = _speed;
    }


    private void Update()
    {
        Move();
    }


    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void Damage(IDamageable damageable)
    {
      
        damageable.GetDamage(5f);

        GameManager.GetInstance().scoreManager.IncrementScore();
        Destroy(gameObject);
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
     
        if(damageable != null && other.tag != "Player")
        {
            Damage(damageable);
        }
    }
}
