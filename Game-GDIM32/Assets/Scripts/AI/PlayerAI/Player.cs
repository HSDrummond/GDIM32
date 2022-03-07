//Player: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //Get Order List
    private List<GameObject> orderList = new List<GameObject>();

    //Get Crop and Animal List
    protected List<GameObject> objectives = new List<GameObject>();
    public List<GameObject> Objectives { get { return objectives; } }

    protected NavMeshAgent agent;
    public NavMeshAgent Agent { get { return agent; } }

    protected Animator anim;
    public Animator Anim { get { return anim; } }

    protected PlayerState currentState;
    public PlayerState CurrentState { get { return currentState; } }
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

    public List<GameObject> UpdateOrder()
    {
        orderList = GetComponent<Order2>().OrderListP2;
        return orderList;
    }


}
