//PlayerState: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerState : MonoBehaviour
{
    public enum PSTATE
    {
        GATHER, SCAN, TRAVEL
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public PSTATE name;
    protected EVENT stage;
    protected Player enemy;
    protected PlayerState nextState;
    protected GameObject target;

    //Order1 order1;
    target = enemy.gameObject;

    public PlayerState(Player _enemy)
    {
        enemy = _enemy;
        stage = EVENT.ENTER;
        name = PSTATE.SCAN;
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
