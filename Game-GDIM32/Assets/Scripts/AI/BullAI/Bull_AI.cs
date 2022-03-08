//Bull_AI: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bull_AI : Bull
{
    private void Start()
    {
        Init();
        checkpoints.AddRange(
                    GameObject.FindGameObjectsWithTag("BullCP"));
    }

    protected override void Init()
    {
        base.Init();
        currentState = new Bull_Idle(this, player);
        visDist = 30.0f;
        visAngle = 30.0f;
        chargeDist = 10.0f;
        attackDist = 3.0f;
    }

    void Update()
    {
        currentState = currentState.Process();
        //Debug.Log(currentState);
    }
}

