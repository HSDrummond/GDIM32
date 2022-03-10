//Player: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //Get Crop and Animal List
    protected List<KeyValuePair<string, GameObject>> objectives = new List<KeyValuePair<string, GameObject>>();
    public List<KeyValuePair<string, GameObject>> Objectives { get { return objectives; } }

    protected NavMeshAgent agent;
    public NavMeshAgent Agent { get { return agent; } }

    protected Animator anim;
    public Animator Anim { get { return anim; } }

    protected PlayerState currentState;
    public PlayerState CurrentState { get { return currentState; } }

    protected GameObject currentTarget;
    public GameObject CurrentTarget { get { return currentTarget; } set { currentTarget = value; } }

    public AudioSource moving;


    void Start()
    {
        //Init();
    }

    protected virtual void Init()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
}
