//Duck_AI: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Duck_AI : Animal
{
    private void Start()
    {
        Init();
        checkpoints.AddRange(
                    GameObject.FindGameObjectsWithTag("DuckCP"));
    }

    protected override void Init()
    {
        base.Init();
        currentState = new Idle(this, player);
        visDist = 20.0f;
        visAngle = 30.0f;
        chargeDist = 7.0f;
        attackDist = 3.0f;
    }

    void Update()
    {
        currentState = currentState.Process();
        Debug.Log(currentState);
    }
}
