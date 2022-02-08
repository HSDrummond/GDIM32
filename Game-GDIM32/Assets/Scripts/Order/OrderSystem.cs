using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdersManager : MonoBehavior
{
    public static OrdersManager _instance = null;

    private void Awake() {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }



    void Start() {
        StartGenerateOrders();
    }

    private void StartGenerateOrders() {

    }

    private IEnumerator GenerateOrder() {
        while(true) {
            yield return new WaitForSeconds(2); //wait 2 seconds
            //generate order

    }


}