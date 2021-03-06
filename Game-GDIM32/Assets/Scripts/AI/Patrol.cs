//Patrol: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{
    int currentIndex = -1;

    public Patrol(Animal _npc, Transform _player)
        : base(_npc, _player)
    {
        name = STATE.PATROL;
        npc.Agent.speed = 2;
        npc.Agent.isStopped = false;
        
    }

    public override void Enter()
    {
        float lastDist = Mathf.Infinity;
        for (int i = 0; i < npc.Checkpoints.Count; i++)
        {
            GameObject thisWP = npc.Checkpoints[i];
            float distance = Vector3.Distance(npc.transform.position, thisWP.transform.position);
            if(distance < lastDist)
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
        if(npc.Agent.remainingDistance < 1)
        {
            if (currentIndex >= npc.Checkpoints.Count - 1)
                currentIndex = 0;
            else
                currentIndex++;
            npc.Agent.SetDestination(npc.Checkpoints[currentIndex].transform.position);
        }

        if (CanSeePlayer())
        {
            if (PlayerHasFood())
            {
                nextState = new Approach(npc, player);
                stage = EVENT.EXIT;
            }
            else if (!PlayerHasFood())
            {
                nextState = new Flee(npc, player);
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
