//HardPlayer_AI: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HardPlayer_AI : Player
{
    //Get Order List
    public List<string> orderList = new List<string>();

    private bool loaded = false;

    public int inventorySize = 3;

    private void Start()
    {
        // 1. waits for crops to spawn initially.
        StartCoroutine(WaitForLoad());
        // 2. starts the first state: scan.
        Init();
    }

    protected override void Init()
    {
        base.Init();
        currentState = new Scan(this);
    }

    void Update()
    {
        if (loaded)
        {
            currentState = currentState.Process();
        }
    }

    public List<string> NewOrder()
    {
        orderList.Clear();
        List<GameObject> templist = GetComponent<Order2>().OrderListP2;
        foreach (var x in templist)
        {
            orderList.Add(x.name);
        }

        Debug.Log("ORDER LIST LENGTH: " + orderList.Count);
        return orderList;
    }

    IEnumerator WaitForLoad()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        loaded = true;

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

}
