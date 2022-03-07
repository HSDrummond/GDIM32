//HardPlayer_AI: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HardPlayer_AI : Player
{
    private void Start()
    {
        Init();
        objectives.AddRange(
                    GameObject.FindGameObjectsWithTag("Crop"));
        objectives.AddRange(
                    GameObject.FindGameObjectsWithTag("Animal"));
    }

    protected override void Init()
    {
        base.Init();
        currentState = new Scan(this);
    }

    void Update()
    {
        currentState = currentState.Process();
        Debug.Log(currentState);
    }
}
