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
        // update all objectives to catch now inactive objectives
        enemy.UpdateObjectives();

        // gets the new order when inventory is cleared and order is fulfilled
        if (enemy.CheckInvSize() == 0)
        {
            enemy.NewOrder();
        }

        // scans objective list for potential targets and sets the current target to the closest one.
        enemy.CurrentTarget = null;

        foreach (var x in enemy.Objectives)
        {
            if (x.Value.activeSelf == true && enemy.orderList.Contains(x.Key))
            {
                if (enemy.CurrentTarget == null)
                {
                    enemy.CurrentTarget = x.Value;
                    enemy.CurrentTarget.name = x.Key;
                }
                else if (Vector2.Distance(x.Value.transform.position, enemy.transform.position) < Vector2.Distance(enemy.CurrentTarget.transform.position, enemy.transform.position))
                {
                    enemy.CurrentTarget = x.Value;
                    enemy.CurrentTarget.name = x.Key;
                }
            }
        }

        stage = EVENT.UPDATE;
    }

    /*
    public override void Enter()
    {
        // 3. copies the order from the Order2 script and puts the name of the items in orderList.
        if (enemy.orderList.Count >= 0)
        {
            if (enemy.orderList.Count == 0)
            {
                enemy.NewOrder();
            }

            enemy.Objectives.Clear();

            List<GameObject> tempScan = new List<GameObject>();
            tempScan.AddRange(
                GameObject.FindGameObjectsWithTag("Crop"));
            tempScan.AddRange(
                GameObject.FindGameObjectsWithTag("Animal"));

            foreach (var x in tempScan)
            {
                enemy.Objectives.Add(new KeyValuePair<string, GameObject>(x.name.Replace("(Clone)", ""), x));
            }
        }

        if (enemy.orderList.Count > 0)
        {
            foreach (KeyValuePair<string, GameObject> objective in enemy.Objectives)
            {
                if (objective.Value.activeSelf == true && enemy.orderList.Contains(objective.Key))
                {
                    if (enemy.Target == null || (Vector3.Distance(objective.Value.transform.position, enemy.transform.position) < Vector3.Distance(enemy.Target.transform.position, enemy.transform.position)))
                    {
                        Debug.Log("current orderlist length: " + enemy.orderList.Count);
                        enemy.Target = objective.Value;
                        enemy.Target.name = objective.Key;
                    }
                }
            }

            enemy.currentItemCollected = false;
            Debug.Log("NEW OBJECTIVE: " + enemy.Target);
        }
        base.Enter();
    }
    */

    public override void Update()
    {
        nextState = new Travel(enemy);
        stage = EVENT.EXIT;
    }


    public override void Exit()
    {
        //anim.ResetTrigger("isRunning");
        // base.Exit();
    }
}
