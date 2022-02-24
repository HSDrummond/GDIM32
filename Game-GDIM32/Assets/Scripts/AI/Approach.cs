//Approach: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Approach : State
{
    public Approach(Animal _npc, Transform _player)
        : base(_npc, _player)
    {
        name = STATE.APPROACH;
        npc.Agent.speed = 1;
        npc.Agent.isStopped = false;
    }

    public override void Enter()
    {
        //anim.SetTrigger("isApproaching");
        base.Enter();
    }

    public override void Update()
    {
        npc.Agent.SetDestination(player.position);
        if (npc.Agent.hasPath)
        {
            if (!PlayerHasFood())
            {
                nextState = new Flee(npc, player);
                stage = EVENT.EXIT;
            }
            else if (!CanSeePlayer())
            {
                nextState = new Patrol(npc, player);
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
