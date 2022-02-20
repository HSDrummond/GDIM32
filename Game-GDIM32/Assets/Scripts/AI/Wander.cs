using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : State
{
    public Wander(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, List<float> _animalStats)
        : base(_npc, _agent, _anim, _player, _animalStats)
    {
        name = STATE.WANDER;
        agent.speed = 2;
        agent.isStopped = false;
        
    }

    Vector3 wanderTarget = Vector3.zero;

    public override void Enter()
    {
        //anim.SetTrigger("isRunning");
        base.Enter();
    }

    public override void Update()
    {
        if (CanSeePlayer())
        {
            nextState = new Flee(npc, agent, anim, player, animalStats);
            stage = EVENT.EXIT;
        }
        else if (!CanSeePlayer())
        {
            float wanderRadius = 10;
            float wanderDistance = 20;
            float wanderJitter = 1;

            wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter, 0, Random.Range(-1.0f, 1.0f) * wanderJitter);

            wanderTarget.Normalize();
            wanderTarget *= wanderRadius;

            Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
            Vector3 targetWorld = this.agent.transform.InverseTransformVector(targetLocal);

            agent.SetDestination(targetWorld);
        }
           
    }

    public override void Exit()
    {
        //anim.ResetTrigger("isRunning");
        base.Exit();
    }
}
