//Travel: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Travel : PlayerState
{
    public Travel(Player _enemy)
           : base(_enemy)
    {
        name = PSTATE.TRAVEL;
        enemy.Agent.speed = 5;
        enemy.Agent.isStopped = false;
    }

    public override void Enter()
    {
        //anim.SetTrigger("isRunning");
        base.Enter();
    }
    public override void Update()
    {
        enemy.Agent.SetDestination(target.transform.position);
        if (enemy.Agent.hasPath)
        {
            if (target.Equals(null))
            {
                nextState = new Scan(enemy);
                stage = EVENT.EXIT;
            }
            else if (enemy.transform.position.Equals(target.transform.position))
            {
                nextState = new Gather(enemy);
                stage = EVENT.EXIT;
            }
        }
    }


    public override void Exit()
    {
        //anim.ResetTrigger("isRunning");
        base.Exit();
    }
}
