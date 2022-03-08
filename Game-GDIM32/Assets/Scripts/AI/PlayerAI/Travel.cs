//Travel: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Travel : PlayerState
{
    public Travel(HardPlayer_AI _enemy)
           : base(_enemy)
    {
        name = STATE.TRAVEL;
        enemy.Agent.speed = 10;
        enemy.Agent.isStopped = false;
    }

    public override void Enter()
    {
        //anim.SetTrigger("isRunning");
        base.Enter();
    }
    public override void Update()
    {
        //Debug.Log("distance" + Vector2.Distance(enemy.Target.transform.position, enemy.transform.position));
        //Debug.Log("Travel Update target: " + enemy.Target);
        if (enemy.orderList.Count == 0)
        {
            nextState = new Scan(enemy);
            stage = EVENT.EXIT;
        }
        else
        {
            enemy.Agent.SetDestination(enemy.Target.transform.position);
        }

        if (enemy.Target == null)
        {
            //Debug.Log("Target is null");
            nextState = new Scan(enemy);
            stage = EVENT.EXIT;
        }
        else if (Vector2.Distance(enemy.Target.transform.position, enemy.transform.position) < 0.2f)
        {
            //Debug.Log("Initiate Gather");
            nextState = new Gather(enemy);
            stage = EVENT.EXIT;
        }
    }


    public override void Exit()
    {
        //anim.ResetTrigger("isRunning");
        base.Exit();
    }
}
