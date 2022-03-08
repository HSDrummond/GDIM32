//Gather: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gather : PlayerState
{
    public Gather(HardPlayer_AI _enemy)
           : base(_enemy)
    {
        name = STATE.GATHER;
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
        /*
        if (enemy.Target.Equals(null))
        {
            nextState = new Scan(enemy);
            stage = EVENT.EXIT;
        }
        */
        if (Vector2.Distance(enemy.Target.transform.position, enemy.transform.position) > 0.3f)
        {
            nextState = new Travel(enemy);
            stage = EVENT.EXIT;
        }
        else
        {
            enemy.Target.GetComponent<PickUp>().PerformPickup2();
            enemy.Objectives.Remove(new KeyValuePair<string, GameObject>(enemy.Target.name, enemy.Target));
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

