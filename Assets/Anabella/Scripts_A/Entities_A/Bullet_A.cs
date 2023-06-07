using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_A : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;

    //Added variable below
    [SerializeField] private string targettag;


    //Method modified to include the new variable targettag
    public void SetBullet(float _damage, float _speed, string _targetTag)
    {
        damage = _damage;
        speed = _speed;
        targettag = _targetTag;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    //Method does not include the increment score, as now it increments when an enemy is killed,
    //and some may take more than one bullet to be destroyed
    private void Damage(IDamageable damageable)
    {
        damageable.GetDamage(damage);
        Destroy(gameObject);
    }


    //Method modified to include the targettag field
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null && other.tag == targettag)
        {
            Damage(damageable);
        }
    }
}
