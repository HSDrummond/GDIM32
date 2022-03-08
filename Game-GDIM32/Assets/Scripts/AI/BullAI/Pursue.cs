//Pursue: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pursue : BullState
{
    public Pursue(Bull _bull, Transform _player, Rigidbody2D _rigidbody2D)
        : base(_bull, _player, _rigidbody2D)
    {
        name = STATE.PURSUE;
        bull.Agent.speed = 5;
        bull.Agent.isStopped = false;
    }

    public override void Enter()
    {
        //anim.SetTrigger("isRunning");
        base.Enter();
    }
    public override void Update()
    {
        bull.Agent.SetDestination(player.position);
        if (bull.Agent.hasPath)
        {
            if (CanAttackPlayer())
            {
                nextState = new Attack(bull, player, rigidbody2D);
                stage = EVENT.EXIT;
            }
            else if (CanChargePlayer())
            {
                nextState = new Charge(bull, player, rigidbody2D);
                stage = EVENT.EXIT;
            }
            else if (!CanSeePlayer())
            {
                nextState = new BullPatrol(bull, player, rigidbody2D);
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
