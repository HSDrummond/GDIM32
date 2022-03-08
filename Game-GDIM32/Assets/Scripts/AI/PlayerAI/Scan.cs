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
        if (enemy.orderList.Count == 0)
        {
            enemy.NewOrder();
            foreach (var x in enemy.orderList)
            {
                Debug.Log("new order check " + enemy.orderList.IndexOf(x) + ": " + x);
            }

            if (enemy.orderList.Count > 0)
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
            }
        }

        if (enemy.orderList.Count > 0)
        {
            enemy.Target = null;
            foreach (KeyValuePair<string, GameObject> objective in enemy.Objectives)
            {
                if (enemy.orderList.Contains(objective.Key))
                {
                    if (enemy.Target == null || (Vector3.Distance(objective.Value.transform.position, enemy.transform.position) < Vector3.Distance(enemy.Target.transform.position, enemy.transform.position)))
                    {
                        foreach (var x in enemy.orderList)
                        {
                            Debug.Log(x);
                        }
                        enemy.Target = objective.Value;
                        enemy.Target.name = objective.Key;
                        Debug.Log("(enemy.Target, enemy.Target.name) (" + enemy.Target + ", " + enemy.Target.name + ")");
                    }
                }
            }

            if (enemy.Target != null)
            {
                // enemy.Target.name = enemy.Target.name.Replace("(Clone)", "");
                enemy.orderList.Remove(enemy.Target.name);
                Debug.Log("NEW OBJECTIVE: " + enemy.Target);
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
