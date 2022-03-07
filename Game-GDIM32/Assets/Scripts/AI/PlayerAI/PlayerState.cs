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
    protected HardPlayer_AI enemy;
    protected PlayerState nextState;

    //Order1 order1;

    public PlayerState(HardPlayer_AI _enemy)
    {
        enemy = _enemy;
        stage = EVENT.ENTER;
        name = STATE.SCAN;
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public PlayerState Process()
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


}
