using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pursue : State
{
    public Pursue(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, List<float> _animalStats)
       : base(_npc, _agent, _anim, _player, _animalStats)
    {
        name = STATE.PURSURE;
        agent.speed = 5;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        //anim.SetTrigger("isRunning");
        base.Enter();
    }
    public override void Update()
    {
        agent.SetDestination(player.position);
        if (agent.hasPath)
        {
            if (CanAttackPlayer())
            {
                nextState = new Attack(npc, agent, anim, player, animalStats);
                stage = EVENT.EXIT;
            }
            else if (!CanSeePlayer())
            {
                nextState = new Patrol(npc, agent, anim, player, animalStats);
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
