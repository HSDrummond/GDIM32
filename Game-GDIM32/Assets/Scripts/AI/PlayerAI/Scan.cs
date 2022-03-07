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
        name = STATE.SCAN;
        enemy.Agent.speed = 5;
        enemy.Agent.isStopped = false;
    }

    public override void Enter()
    {
        enemy.Objectives.AddRange(
            GameObject.FindGameObjectsWithTag("Crop"));
        enemy.Objectives.AddRange(
                    GameObject.FindGameObjectsWithTag("Animal"));

        foreach (var x in enemy.Objectives)
        {
            Debug.Log("objective list index " + enemy.Objectives.IndexOf(x) + ": " + x);
        }
        //anim.SetTrigger("isStopped");
        Debug.Log("Scan Enter target:" + target);
        target = GameObject.FindGameObjectWithTag("farthestTarget");
        Debug.Log("Scan Enter target:" + target);

        foreach (GameObject objective in enemy.Objectives)
        {
            Debug.Log("POTENTIAL OBJECTIVE:" + objective);
            objective.name = objective.name.Replace("(Clone)", "");
            if (enemy.UpdateOrder().Contains(objective))
            {
                //Check the current order and see if the objective is closer then the previous objective
                if (Vector3.Distance(objective.transform.position, enemy.transform.position) <
                   Vector3.Distance(target.transform.position, enemy.transform.position))
                {
                    Debug.Log("NEW OBJECTIVE: " + objective);
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
