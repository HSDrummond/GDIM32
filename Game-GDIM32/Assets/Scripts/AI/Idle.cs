using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, List<float> _animalStats)
        : base(_npc, _agent, _anim, _player, _animalStats)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        //anim.SetTrigger("isWander");
        base.Enter();
    }

    public override void Update()
    {
        if (CanSeePlayer())
        {
            nextState = new Pursue(npc, agent, anim, player, animalStats);
            stage = EVENT.EXIT;
        }
        else if(Random.Range(0,100) < 10)
        {
            nextState = new Patrol(npc, agent, anim, player, animalStats);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        //anim.ResetTrigger("isWander");
        base.Exit();
    }
}
