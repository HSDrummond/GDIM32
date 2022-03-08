//Charge: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : BullState
{
    public Charge(Bull _bull, Transform _player, Rigidbody2D _rigidbody2D)
        : base(_bull, _player, _rigidbody2D)
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
        //Bull Charges forward 
        Vector3 ChargeDirection = player.position - bull.transform.position;
        float lookAhead = ChargeDirection.magnitude;
        //Vector3 direction = player.position - bull.transform.position;
        //float angle = Vector3.Angle(direction, bull.transform.forward);
        ChargeDirection.z = 0;
        //bull.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);

        bull.Agent.SetDestination(ChargeDirection * lookAhead);
        if (bull.Agent.hasPath)
        {
            if (CanAttackPlayer())
            {
                nextState = new Attack(bull, player, rigidbody2D);
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