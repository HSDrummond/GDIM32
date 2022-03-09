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
        if (Vector2.Distance(enemy.CurrentTarget.transform.position, enemy.transform.position) < 0.3f)
        {
            enemy.CurrentTarget.GetComponent<PickUp>().PerformPickup2();
            ExecutePickUp();

            nextState = new Scan(enemy);
            stage = EVENT.EXIT;
        }
        else
        {
            nextState = new Travel(enemy);
            stage = EVENT.EXIT;
        }
    }

    private void ExecutePickUp()
    {
        enemy.orderList.Remove(enemy.CurrentTarget.name);
        enemy.inventorySize += 1;

        if (enemy.inventorySize == 3 && enemy.orderList.Count == 0)
        {
            enemy.inventorySize = 0;
        }
    }

    /*
    public override void Update()
    {
        if (enemy.Target.Equals(null))
        {
            nextState = new Scan(enemy);
            stage = EVENT.EXIT;
        }
        if (Vector2.Distance(enemy.Target.transform.position, enemy.transform.position) > 0.3f)
        {
            nextState = new Travel(enemy);
            stage = EVENT.EXIT;
        }
        else if (Vector2.Distance(enemy.Target.transform.position, enemy.transform.position) <= 0.3f && enemy.currentItemCollected == false)
        {
            enemy.currentItemCollected = true;
            Debug.Log("PICKED UP: " + enemy.Target);
            enemy.Objectives.Remove(new KeyValuePair<string, GameObject>(enemy.Target.name, enemy.Target));
            enemy.orderList.Remove(enemy.Target.name);
            enemy.Target.GetComponent<PickUp>().PerformPickup2();
            enemy.Target = null;

            nextState = new Scan(enemy);
            stage = EVENT.EXIT;
        }
        else if (enemy.currentItemCollected == true)
        {
            nextState = new Scan(enemy);
            stage = EVENT.EXIT;
        }

    }
    */


    public override void Exit()
    {
        //anim.ResetTrigger("isRunning");
        base.Exit();
    }
}

