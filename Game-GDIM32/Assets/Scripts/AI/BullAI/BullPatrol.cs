//BullPatrol: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BullPatrol : BullState
{
    int currentIndex = -1;

    public BullPatrol(Bull _bull, Transform _player)
        : base(_bull, _player)
    {
        name = STATE.PATROL;
        bull.Agent.speed = 2;
        bull.Agent.isStopped = false;

    }

    public override void Enter()
    {
        float lastDist = Mathf.Infinity;
        for (int i = 0; i < bull.Checkpoints.Count; i++)
        {
            GameObject thisWP = bull.Checkpoints[i];
            float distance = Vector3.Distance(bull.transform.position, thisWP.transform.position);
            if (distance < lastDist)
            {
                currentIndex = i - 1;
                lastDist = distance;
            }
        }
        //anim.SetTrigger("isWalking");
        base.Enter();
    }

    public override void Update()
    {
        if (bull.Agent.remainingDistance < 1)
        {
            if (currentIndex >= bull.Checkpoints.Count - 1)
                currentIndex = 0;
            else
                currentIndex++;
            bull.Agent.SetDestination(bull.Checkpoints[currentIndex].transform.position);
        }

        if (CanSeePlayer())
        {
            
            if (CanAttackPlayer())
            {
                nextState = new Attack(bull, player);
                stage = EVENT.EXIT;
            }
            else if (CanChargePlayer())
            {
                nextState = new Charge(bull, player);
                stage = EVENT.EXIT;
            }
        }
    }

    public override void Exit()
    {
        //anim.ResetTrigger("isWalking");
        base.Exit();
    }
}
