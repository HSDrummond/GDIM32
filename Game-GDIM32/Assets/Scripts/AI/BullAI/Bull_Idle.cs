//Bull_Idle: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull_Idle : BullState
{
    public Bull_Idle(Bull _bull, Transform _player, Rigidbody2D _rigidbody2D)
        : base(_bull, _player, _rigidbody2D)
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
            nextState = new Pursue(bull, player, rigidbody2D);
            stage = EVENT.EXIT;
        }
        else if (CanChargePlayer())
        {
            nextState = new Charge(bull, player, rigidbody2D);
            stage = EVENT.EXIT;
        }
        else if (CanAttackPlayer())
        {
            nextState = new Attack(bull, player, rigidbody2D);
            stage = EVENT.EXIT;
        }
        else
        {
            //Timer
            nextState = new BullPatrol(bull, player, rigidbody2D);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        //anim.ResetTrigger("isIdle");
        base.Exit();
    }
}
