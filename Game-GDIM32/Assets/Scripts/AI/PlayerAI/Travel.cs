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
        enemy.Agent.speed = 5;
        enemy.Agent.isStopped = false;

        Debug.Log("TravelState: " + enemy.Target);
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
        enemy.Agent.SetDestination(enemy.Target.transform.position);
        if (enemy.Agent.hasPath)
        {
            if (enemy.Target.Equals(null))
            {
                //Debug.Log("Target is null");
                nextState = new Scan(enemy);
                stage = EVENT.EXIT;
            }

            //Debug.Log("travelling...");
        }

        if (Vector2.Distance(enemy.Target.transform.position, enemy.transform.position) < 0.2f)
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
