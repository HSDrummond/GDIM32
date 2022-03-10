//Attack: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : BullState
{
    //float rotationSpeed = 2.0f;
    //AudioSource attack;
    public Attack(Bull _bull, Transform _player, Rigidbody2D _rigidbody2D)
        : base(_bull, _player, _rigidbody2D)
    {
        name = STATE.ATTACK;
        //attack = _npc.GetComponent<AudioSource>();
    }

    public override void Enter()
    {
        //anim.SetTrigger("isShooting");
        bull.Agent.isStopped = true;
        bull.source.Play();
        base.Enter();
    }
    public override void Update()
    {
        /*Vector3 direction = player.position - bull.transform.position;
        float angle = Vector3.Angle(direction, bull.transform.forward);
        direction.y = 0;

        bull.transform.rotation = Quaternion.Slerp(bull.transform.rotation,
            Quaternion.LookRotation(direction),
            Time.deltaTime * rotationSpeed);*/

        //Push Player away
        Vector3 direction = player.position - bull.transform.position;
        //float angle = Vector3.Angle(direction, bull.transform.forward);
        direction.z = 0;

        rigidbody2D.AddForce(direction/2, ForceMode2D.Impulse);





        if (!CanAttackPlayer())
        {
            nextState = new Bull_Idle(bull, player, rigidbody2D);
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
