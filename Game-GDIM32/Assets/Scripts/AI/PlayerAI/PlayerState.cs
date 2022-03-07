//PlayerState: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerState
{
    public enum STATE
    {
        GATHER, SCAN, TRAVEL
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected Player enemy;
    protected PlayerState nextState;
    protected GameObject target;

    //Order1 order1;

    public PlayerState(Player _enemy)
    {
        enemy = _enemy;
        stage = EVENT.ENTER;
        name = STATE.SCAN;
        target = GameObject.FindGameObjectWithTag("farthestTarget");
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public PlayerState Process()
    {
        Debug.Log("PlayerState Process target: " + target);
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }


}
