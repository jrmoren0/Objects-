using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunEnemy_A : Enemy_A
{
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
        //Set enemy weapon
        weapon = new Weapon_A("MachineGunEnemy Weapon", weaponDamage, weaponSpeed);
    }

    protected override void Update()
    {
        if (target != null && GameManager_A.GetInstance().isGameActive)
        {
            if (Vector2.Distance(transform.position, target.position) >= attackRange)//approaches the player to be on an attack range
            {
                Move(target.position, speed);
                coroutineStarted = false;
                StopAllCoroutines();
            }
            else if (!coroutineStarted)//when close enough, it starts shooting the player
            {
                coroutineStarted = true;
                StartCoroutine(ShootingInterval());
            }
            else
            {
                Move(transform.position, target.position);//it always looks to be facing and shooting towards the player
            }
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
