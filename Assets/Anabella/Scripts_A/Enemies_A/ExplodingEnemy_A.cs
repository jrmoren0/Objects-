using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy_A : Enemy_A
{
    [SerializeField] private float damage = 40f;

    private void Damage(IDamageable damageable)
    {
        damageable.GetDamage(damage);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null && other.CompareTag("Player"))
        {
            Damage(damageable);
        }
    }
}
