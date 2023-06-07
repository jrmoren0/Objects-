using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy_A : Enemy_A
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float timeToDie;

    [SerializeField] private float weaponDamage;
    [SerializeField] private float weaponSpeed;

    [SerializeField] private Bullet_A bulletPrefab;
    [SerializeField] private float shootingInterval;
    private bool coroutineStarted = false;

    public float attackRange;


    protected override void Start()
    {
        base.Start();
        lineRenderer.enabled = false;
        //Set enemy weapon
        weapon = new Weapon_A("ShooterEnemy Weapon", weaponDamage, weaponSpeed);
    }

    protected override void Update()
    {
        if (target != null && GameManager_A.GetInstance().isGameActive)
        {
            if (Vector2.Distance(transform.position, target.position) >= attackRange)
            {
                Move(target.position, speed);
                coroutineStarted = false;
                lineRenderer.enabled = false;
                StopAllCoroutines();
            }
            else if (!coroutineStarted)
            {
                lineRenderer.enabled = true;
                coroutineStarted = true;
                StartCoroutine(ShootingInterval());
            }
            else
            {
                Move(transform.position, target.position);
                // Set the line renderer's start and end points
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, target.position);
            }

        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    public override void Attack()
    {
        weapon.Shoot(bulletPrefab, this, "Player", timeToDie);
    }


    private IEnumerator ShootingInterval()
    {
        while (coroutineStarted && GameManager_A.GetInstance().isGameActive)
        {
            yield return new WaitForSeconds(shootingInterval);
            Attack();
        }
    }
}
