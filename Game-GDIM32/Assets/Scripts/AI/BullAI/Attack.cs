//Attack: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : BullState
{
    float rotationSpeed = 2.0f;
    //AudioSource attack;
    public Attack(Bull _bull, Transform _player)
        : base(_bull, _player)
    {
        name = STATE.ATTACK;
        //attack = _npc.GetComponent<AudioSource>();
    }

    public override void Enter()
    {
        //anim.SetTrigger("isShooting");
        bull.Agent.isStopped = true;
        //attack.Play();
        base.Enter();
    }
    public override void Update()
    {
        Vector3 direction = player.position - bull.transform.position;
        float angle = Vector3.Angle(direction, bull.transform.forward);
        direction.y = 0;

        bull.transform.rotation = Quaternion.Slerp(bull.transform.rotation,
            Quaternion.LookRotation(direction),
            Time.deltaTime * rotationSpeed);
        if (!CanAttackPlayer())
        {
            nextState = new Bull_Idle(bull, player);
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
