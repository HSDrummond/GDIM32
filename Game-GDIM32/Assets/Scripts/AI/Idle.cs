//Idle: Shiloh
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    public Idle(Animal _npc, Transform _player)
        : base(_npc, _player)
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
            if (PlayerHasFood())
            {
                nextState = new Approach(npc, player);
                stage = EVENT.EXIT;
            }
            else
            {
                nextState = new Flee(npc,player);
                stage = EVENT.EXIT;
            }
        }
        else
        {
            //Timer
            nextState = new Patrol(npc, player);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        //anim.ResetTrigger("isIdle");
        base.Exit();
    }
}
