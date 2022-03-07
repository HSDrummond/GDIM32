//ScanCrops: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Scan : PlayerState
{
    public Scan(Player _enemy)
            : base(_enemy)
    {
        name = PSTATE.SCAN;
        enemy.Agent.speed = 5;
        enemy.Agent.isStopped = false;
    }

    public override void Enter()
    {
        //anim.SetTrigger("isStopped");
        target = enemy.gameObject;
        foreach (GameObject objective in enemy.Objectives)
        {
            objective.name = objective.name.Replace("(Clone)", "");
            if (enemy.UpdateOrder().Contains(objective))
            {
                //Check the current order and see if the objective is closer then the previous objective
                if (Vector3.Distance(objective.transform.position, enemy.transform.position) <
                   Vector3.Distance(target.transform.position, enemy.transform.position))
                {
                    target = objective;
                }
            }
        }
        base.Enter();
        
    }
    public override void Update()
    {
        nextState = new Travel(enemy);
        stage = EVENT.EXIT;
    }


    public override void Exit()
    {
        //anim.ResetTrigger("isRunning");
        base.Exit();
    }
}
