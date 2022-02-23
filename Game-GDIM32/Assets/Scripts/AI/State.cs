using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State 
{
    public enum STATE
    {
        IDLE, PATROL, PURSUE, ATTACK, FLEE, WANDER, APPROACH
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected Animal npc;
    protected Transform player;
    protected State nextState;

    //Order1 order1;

    public State(Animal _npc, Transform _player)
    {
        npc = _npc;
        stage = EVENT.ENTER;
        player = _player;
        name = STATE.IDLE;
        //Dict would be better, right now not bullet proof
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public State Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if(stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }

    public bool CanSeePlayer()
    {
        Vector3 direction = player.position - npc.transform.position;
        float angle = Vector3.Angle(direction, -npc.transform.right);

        if(direction.magnitude < npc.VisDist && angle < npc.VisAngle)
        {
            return true;
        }
        return false;
    }

    public bool CanChargePlayer()
    {
        Vector3 direction = player.position - npc.transform.position;
        if(direction.magnitude < npc.ChargeDist)
        {
            return true;
        }
        return false;
    }

    public bool CanAttackPlayer()
    {
        Vector3 direction = player.position - npc.transform.position;
        if (direction.magnitude < npc.AttackDist)
        {
            return true;
        }
        return false;
    }

    public bool PlayerHasFood()
    {
        List<string> InvenList = Order1.instance.GetInven();

        if (InvenList.Contains("Corn") || InvenList.Contains("Wheat"))
        {
            return true;
        }
        return false;
    }

    public bool IsPlayerBehind()
    {
        Vector3 direction = npc.transform.position - player.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        if(direction.magnitude < 5 && angle < 30)
        {
            return true;
        }
        return false;
    }


    //void Flee(Vector3 location)
    //{
        //Vector3 fleeVector = location - this.transform.position;
        //agent.SetDestination(this.transform.position - fleeVector);
    //}
}

