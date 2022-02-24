//Fish_AI: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_AI : Animal
{
    private void Start()
    {
        Init();
        checkpoints.AddRange(
                    GameObject.FindGameObjectsWithTag("FishCP"));
    }

    protected override void Init()
    {
        base.Init();
        currentState = new Idle(this, player);
        visDist = 1.0f;
        visAngle = 30.0f;
        chargeDist = 1.0f;
        attackDist = 1.0f;
    }

    void Update()
    {
        currentState = currentState.Process();
        //Debug.Log(currentState);
    }
}
