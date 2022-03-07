//Gather: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gather : PlayerState
{
    public Gather(Player _enemy)
           : base(_enemy)
    {
        name = PSTATE.GATHER;
        enemy.Agent.speed = 0;
        enemy.Agent.isStopped = true;
    }

    public override void Enter()
    {
        //anim.SetTrigger("isStopped");
        base.Enter();
    }
    public override void Update()
    {
        
        if (target.Equals(null))
        {
            nextState = new Scan(enemy);
            stage = EVENT.EXIT;
        }
        else if (!enemy.transform.position.Equals(target.transform.position))
        {
            nextState = new Travel(enemy);
            stage = EVENT.EXIT;
        }
        else
        {
            target.GetComponent<PickUp>().PerformPickup2();
            nextState = new Scan(enemy);
            stage = EVENT.EXIT;
        }
        
    }


    public override void Exit()
    {
        //anim.ResetTrigger("isRunning");
        base.Exit();
    }
}

