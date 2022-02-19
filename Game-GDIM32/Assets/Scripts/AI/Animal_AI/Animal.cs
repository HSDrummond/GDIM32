using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Transform player;
    State currentState;

    float visDist = 10.0f;
    float visAngle = 30.0f;
    float chargeDist = 7.0f;
    float attackDist = 3.0f;

    private List<float> animalStats = new List<float>();

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        animalStats.Add(visDist);
        animalStats.Add(visAngle);
        animalStats.Add(chargeDist);
        animalStats.Add(attackDist);
        currentState = new Idle(this.gameObject, agent, anim, player, animalStats);

    }

    void Update()
    {
        currentState = currentState.Process();
    }
}
