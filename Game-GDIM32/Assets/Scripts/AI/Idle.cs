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
        //anim.SetTrigger("isEating");
        base.Enter();
    }

    public override void Update()
    {
        if (CanSeePlayer())
        {
            if (npc.gameObject.tag == "Bull")
            {
                nextState = new Pursue(npc, agent, anim, player, animalStats);
                stage = EVENT.EXIT;
            }
            else if (PlayerHasFood())
            {
                nextState = new Approach(npc, agent, anim, player, animalStats);
                stage = EVENT.EXIT;
            }
            else
            {
                nextState = new Flee(npc, agent, anim, player, animalStats);
                stage = EVENT.EXIT;
            }
        }
    }
    public override void Exit()
    {
        //anim.ResetTrigger("isWander");
        base.Exit();
    }
}
