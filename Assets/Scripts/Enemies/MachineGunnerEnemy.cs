using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunnerEnemy : Enemy
{
    public float attackRange;
    public float shootingRange;
    public GameObject bullet;
    public GameObject machineGun;
    //public float speed;
    public float fireRate = 0.001f;
    private float nextFireTime;


    


    protected override void Update()
    {
        //base.Update();
        float distanceFromPlayer = Vector2.Distance(target.position, transform.position);

        if(distanceFromPlayer < attackRange && distanceFromPlayer>shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, target.position, base.speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime <Time.time)
        {
            Instantiate(bullet, machineGun.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }

        if (Vector2.Distance(transform.position, target.position) < attackRange)
        {
            Attack();
        }

       
    }

    public override void Attack()
    {
        base.Attack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
