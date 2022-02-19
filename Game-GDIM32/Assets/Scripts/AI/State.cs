using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State 
{
    public enum STATE
    {
        IDLE, PATROL, PURSURE, ATTACK, FLEE, WANDER
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    protected State nextState;
    protected NavMeshAgent agent;
    protected List<float> animalStats = new List<float>();
    float visDist;
    float visAngle;
    float chargeDist;
    float attackDist;

    



    public State(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, List<float> _animalStats)
    {
        npc = _npc;
        agent = _agent;
        anim = _anim;
        stage = EVENT.ENTER;
        player = _player;
        animalStats = _animalStats;
        visDist = _animalStats[0];
        visAngle = _animalStats[1];
        chargeDist = _animalStats[2];
        attackDist = _animalStats[3];
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
        float angle = Vector3.Angle(direction, npc.transform.forward);

        if(direction.magnitude < visDist && angle < visAngle)
        {
            return true;
        }
        return false;
    }

    public bool CanChargePlayer()
    {
        Vector3 direction = player.position - npc.transform.position;
        if(direction.magnitude < chargeDist)
        {
            return true;
        }
        return false;
    }

    public bool CanAttackPlayer()
    {
        Vector3 direction = player.position - npc.transform.position;
        if (direction.magnitude < attackDist)
        {
            return true;
        }
        return false;
    }


    void Flee(Vector3 location)
    {
        //Vector3 fleeVector = location - this.transform.position;
        //agent.SetDestination(this.transform.position - fleeVector);
    }
}

