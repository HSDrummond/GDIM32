//Pursue: Shiloh
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pursue : State
{
    public Pursue(Animal _npc, Transform _player)
        : base(_npc, _player)
    {
        name = STATE.PURSUE;
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
        npc.Agent.SetDestination(player.position);
        if (npc.Agent.hasPath)
        {
            if (CanAttackPlayer())
            {
                nextState = new Attack(npc, player);
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
