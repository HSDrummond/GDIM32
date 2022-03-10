//BullState: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BullState
{
    public enum STATE
    {
        IDLE, PATROL, PURSUE, CHARGE, ATTACK
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected Bull bull;
    protected Transform player;
    protected Rigidbody2D rigidbody2D;
    protected BullState nextState;

    //Order1 order1;

    public BullState(Bull _bull, Transform _player, Rigidbody2D _rigidbody2D)
    {
        bull = _bull;
        stage = EVENT.ENTER;
        player = _player;
        name = STATE.IDLE;
        rigidbody2D = _rigidbody2D;
        
        //Dict would be better, right now not bullet proof
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public BullState Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }

    public bool CanSeePlayer()
    {
        Vector3 direction = player.position - bull.transform.position;
        float angle = Vector3.Angle(direction, -bull.transform.right);

        if (direction.magnitude < bull.VisDist && angle < bull.VisAngle)
        {
            return true;
        }
        return false;
    }

    public bool CanChargePlayer()
    {
        Vector3 direction = player.position - bull.transform.position;
        if (direction.magnitude < bull.ChargeDist)
        {
            return true;
        }
        return false;
    }

    public bool CanAttackPlayer()
    {
        Vector3 direction = player.position - bull.transform.position;
        if (direction.magnitude < bull.AttackDist)
        {
            return true;
        }
        return false;
    }

    public bool IsPlayerBehind()
    {
        Vector3 direction = bull.transform.position - player.position;
        float angle = Vector3.Angle(direction, bull.transform.forward);
        if (direction.magnitude < 5 && angle < 30)
        {
            return true;
        }
        return false;
    }

}