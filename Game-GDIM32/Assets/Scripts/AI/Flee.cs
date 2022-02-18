using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flee : State
{
    public Flee(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.FLEE;
        agent.speed = 5;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        //anim.SetTrigger("isRunning");
        base.Enter();
    }
    public override void Update()
    {
        //Vector3 targetDir = player.transform.position - this.transform.position;
        //float lookAhead = targetDir.magnitude / (agent.speed + target.GetComponent<Drive>().currentSpeed);
        //Flee(target.transform.position + target.transform.forward * lookAhead);
        if (agent.hasPath)
        {
            if (!CanSeePlayer())
            {
                nextState = new Wander(npc, agent, anim, player);
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
