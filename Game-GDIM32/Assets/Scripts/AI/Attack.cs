using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : State
{
    float rotationSpeed = 2.0f;
    //AudioSource attack;
    public Attack(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, List<float> _animalStats)
        : base(_npc, _agent, _anim, _player, _animalStats)
    {
        name = STATE.ATTACK;
        //attack = _npc.GetComponent<AudioSource>();
    }

    public override void Enter()
    {
        anim.SetTrigger("isShooting");
        agent.isStopped = true;
        //attack.Play();
        base.Enter();
    }
    public override void Update()
    {
        Vector3 direction = player.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        direction.y = 0;

        npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation,
            Quaternion.LookRotation(direction),
            Time.deltaTime * rotationSpeed);
        if (!CanAttackPlayer())
        {
            nextState = new Idle(npc, agent, anim, player, animalStats);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        //anim.ResetTrigger("isAttacking");
        //attack.Stop;
        base.Exit();
    }


}
