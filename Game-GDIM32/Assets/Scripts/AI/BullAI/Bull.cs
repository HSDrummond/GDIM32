//Bull: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bull : MonoBehaviour
{
    protected float visDist;
    protected float visAngle;
    protected float chargeDist;
    protected float attackDist;

    public float VisDist { get { return visDist; } }
    public float VisAngle { get { return visAngle; } }
    public float ChargeDist { get { return chargeDist; } }
    public float AttackDist { get { return attackDist; } }

    protected List<GameObject> checkpoints = new List<GameObject>();
    public List<GameObject> Checkpoints { get { return checkpoints; } }

    protected NavMeshAgent agent;
    public NavMeshAgent Agent { get { return agent; } }

    protected Animator anim;
    public Animator Anim { get { return anim; } }

    protected BullState currentState;
    public BullState CurrentState { get { return currentState; } }

    [SerializeField]
    protected Transform player;


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
