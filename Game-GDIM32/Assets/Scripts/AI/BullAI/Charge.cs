//Charge: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : BullState
{
    public Charge(Bull _bull, Transform _player)
        : base(_bull, _player)
    {
        name = STATE.CHARGE;
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
                nextState = new Attack(bull, player);
                stage = EVENT.EXIT;
            }
            else if (CanChargePlayer())
            {
                nextState = new Charge(bull, player);
                stage = EVENT.EXIT;
            }
            else if (!CanSeePlayer())
            {
                nextState = new BullPatrol(bull, player);
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