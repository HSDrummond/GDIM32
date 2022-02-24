//OrderUI1: Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderUI1 : MonoBehaviour
{
    public GameObject OrderPanelP1;

    Order1 order1;

    Order1Slot[] slots;



    void Start()
    {
        order1 = Order1.instance;
        slots = OrderPanelP1.GetComponentsInChildren<Order1Slot>();
        order1.onOrderChangedCallback += UpdateUI;
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < order1.OrderListP1.Count)
            {
                slots[i].AddItem(order1.OrderListP1[i]);
                //Debug.Log("Adding Item to OrderListP1UI");
            }
            else
                slots[i].ClearSlot();
        }
    }
}
