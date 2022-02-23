using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flee : State
{
    public Flee(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, List<float> _animalStats)
        : base(_npc, _agent, _anim, _player, _animalStats)
    {
        name = STATE.FLEE;
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
        //Vector3 FleeDirection = npc.transform.position - player.transform.position;
        //float lookAhead = FleeDirection.magnitude;
        agent.SetDestination(npc.transform.position - player.transform.position);

        if (agent.hasPath)
        {
            if (PlayerHasFood())
            {
                nextState = new Approach(npc, agent, anim, player, animalStats);
                stage = EVENT.EXIT;
            }
            else if (!IsPlayerBehind())
            {
                nextState = new Patrol(npc, agent, anim, player, animalStats);
                stage = EVENT.EXIT;
            }
            else if (!CanSeePlayer())
            {
                nextState = new Wander(npc, agent, anim, player, animalStats);
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
