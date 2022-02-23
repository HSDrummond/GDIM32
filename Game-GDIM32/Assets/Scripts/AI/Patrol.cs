using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{
    int currentIndex = -1;

    public Patrol(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, List<float> _animalStats)
        : base(_npc, _agent, _anim, _player, _animalStats)
    {
        name = STATE.PATROL;
        agent.speed = 2;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        float lastDist = Mathf.Infinity;
        for (int i = 0; i < GameEnvironment.Singleton.Checkpoints.Count; i++)
        {
            GameObject thisWP = GameEnvironment.Singleton.Checkpoints[i];
            float distance = Vector3.Distance(npc.transform.position, thisWP.transform.position);
            if(distance < lastDist)
            {
                currentIndex = i - 1;
                lastDist = distance;
            }
        }
        //anim.SetTrigger("isWalking");
        base.Enter();
    }

    public override void Update()
    {
        if(agent.remainingDistance < 1)
        {
            if (currentIndex >= GameEnvironment.Singleton.Checkpoints.Count - 1)
                currentIndex = 0;
            else
                currentIndex++;
            agent.SetDestination(GameEnvironment.Singleton.Checkpoints[currentIndex].transform.position);
        }

        if (CanSeePlayer())
        {
            if (npc.gameObject.tag == "Bull")
            {
                nextState = new Pursue(npc, agent, anim, player, animalStats);
                stage = EVENT.EXIT;
            }
            else if (PlayerHasFood())
            {
                nextState = new Approach(npc, agent, anim, player, animalStats);
                stage = EVENT.EXIT;
            }
            else if (!PlayerHasFood())
            {
                nextState = new Flee(npc, agent, anim, player, animalStats);
                stage = EVENT.EXIT;
            }
        }
    }

    public override void Exit()
    {
        //anim.ResetTrigger("isWalking");
        base.Exit();
    }
}