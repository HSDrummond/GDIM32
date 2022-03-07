//ScanCrops: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Scan : PlayerState
{
    public Scan(HardPlayer_AI _enemy)
            : base(_enemy)
    {
        name = STATE.SCAN;
        enemy.Agent.speed = 5;
        enemy.Agent.isStopped = false;
        
        Debug.Log("ScanState: " + enemy.Target);
    }

    public override void Enter()
    {
        List<GameObject> tempScan = new List<GameObject>();

        tempScan.AddRange(
            GameObject.FindGameObjectsWithTag("Crop"));
        tempScan.AddRange(
            GameObject.FindGameObjectsWithTag("Animal"));

        enemy.Objectives.Clear();
        foreach (var x in tempScan)
        {
            enemy.Objectives.Add(new KeyValuePair<string, GameObject>(x.name.Replace("(Clone)", ""), x));
        }

        //anim.SetTrigger("isStopped");

        if (enemy.Target == null)
        {
            enemy.Target = GameObject.FindGameObjectWithTag("farthestTarget");
        }

        enemy.UpdateOrder();
        foreach (KeyValuePair<string, GameObject> objective in enemy.Objectives)
        {
            if (enemy.orderList.Contains(objective.Key))
            {
                //Check the current order and see if the objective is closer then the previous objective
                if (Vector3.Distance(objective.Value.transform.position, enemy.transform.position) <
                   Vector3.Distance(enemy.Target.transform.position, enemy.transform.position))
                {
                    //Debug.Log("POTENTIAL OBJECTIVE:" + objective);
                    enemy.Target = objective.Value;
                }
            }
        }

        Debug.Log("NEW OBJECTIVE: " + enemy.Target);

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
