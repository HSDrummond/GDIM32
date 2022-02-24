//Flee: Shiloh
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flee : State
{
    public Flee(Animal _npc, Transform _player)
        : base(_npc, _player)
    {
        name = STATE.FLEE;
        npc.Agent.speed = 5;
        npc.Agent.isStopped = false;
    }

    public override void Enter()
    {
        //anim.SetTrigger("isRunning");
        base.Enter();
    }
    public override void Update()
    {
        //Vector3 FleeDirection = npc.transform.position - player.transform.position;
        //float lookAhead = FleeDirection.magnitude;
        npc.Agent.SetDestination(npc.transform.position - player.transform.position);

        if (npc.Agent.hasPath)
        {
            if (PlayerHasFood())
            {
                nextState = new Approach(npc, player);
                stage = EVENT.EXIT;
            }
            else if (!IsPlayerBehind())
            {
                nextState = new Patrol(npc, player);
                stage = EVENT.EXIT;
            }
            else if (!CanSeePlayer())
            {
                nextState = new Wander(npc, player);
                stage = EVENT.EXIT;
            }
        }
    }
    public override void Exit()
    {
        //anim.ResetTrigger("isRunning");
        base.Exit();
    }
}
