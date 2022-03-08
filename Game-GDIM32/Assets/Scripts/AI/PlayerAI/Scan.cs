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
    }

    public override void Enter()
    {
        if (enemy.orderList.Count == 0)
        {
            enemy.UpdateOrder();

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
        }


        //anim.SetTrigger("isStopped");
        if (enemy.orderList.Count > 0)
        {
            enemy.Target = null;
            foreach (KeyValuePair<string, GameObject> objective in enemy.Objectives)
            {
                if (enemy.orderList.Contains(objective.Key))
                {
                    Debug.Log("objective in list: " + objective.Key);

                    // if there is no target, set a target; then find closest target.
                    if (enemy.Target == null || (Vector3.Distance(objective.Value.transform.position, enemy.transform.position) <
                       Vector3.Distance(enemy.Target.transform.position, enemy.transform.position)))
                    {
                        //Debug.Log("POTENTIAL OBJECTIVE:" + objective);
                        enemy.Target = objective.Value;
                    }
                }
            }

            Debug.Log("NEW OBJECTIVE: " + enemy.Target);
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
