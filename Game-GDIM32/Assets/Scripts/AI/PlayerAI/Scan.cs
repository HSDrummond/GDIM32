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
        // 3. copies the order from the Order2 script and puts the name of the items in orderList.
        if (enemy.orderList.Count >= 0)
        {
            if (enemy.orderList.Count == 0)
            {
                enemy.orderList.Clear();
                enemy.NewOrder();
                foreach (var x in enemy.orderList)
                {
                    Debug.Log("new order check " + enemy.orderList.IndexOf(x) + ": " + x);
                }
                Debug.Log("new order check length: " + enemy.orderList.Count);
            }

            List<GameObject> tempScan = new List<GameObject>();

            tempScan.AddRange(
                GameObject.FindGameObjectsWithTag("Crop"));
            tempScan.AddRange(
                GameObject.FindGameObjectsWithTag("Animal"));

            enemy.Objectives.Clear();
            Debug.Log("cleared" + enemy.Objectives);

            foreach (var x in tempScan)
            {
                enemy.Objectives.Add(new KeyValuePair<string, GameObject>(x.name.Replace("(Clone)", ""), x));
            }
        }

        if (enemy.orderList.Count > 0)
        {

            foreach (KeyValuePair<string, GameObject> objective in enemy.Objectives)
            {
                if (enemy.orderList.Contains(objective.Key))
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
