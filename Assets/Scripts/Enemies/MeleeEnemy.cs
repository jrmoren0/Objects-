using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float attackRange;

    private float timer = 0;

    //enableAttackBool
    private bool enableAttack = true;

    protected override void Update()
    {
        base.Update();

        if (Vector2.Distance(transform.position, target.position) < attackRange)
        {
            Attack(1);
        }
       
        
    }

    public override void Attack(float rate)
    {
        if (timer == 0)
        {
            target.GetComponent<Player>().GetDamage(5);
            //timer += Time.deltaTime;
            
        }

        if(timer < rate)
        {
            timer += Time.deltaTime;
            return;
        }
        else
        {
            //target.GetComponent<Player>().GetDamage(5);
            //enableAttack = true;
            timer = 0;
        }
    }
}
