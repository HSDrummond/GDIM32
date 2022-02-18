using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bull_AI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Transform player;
    State currentState;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        currentState = new Idle(this.gameObject, agent, anim, player);

    }

    void Update()
    {
        currentState = currentState.Process();
    }
}
