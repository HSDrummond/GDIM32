using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order2UI : MonoBehaviour
{
    public GameObject OrderPanelP2;

    Order2 order2;

    Order1Slot[] slots;



    void Start()
    {
        order2 = Order2.instance;
        slots = OrderPanelP2.GetComponentsInChildren<Order1Slot>();
        order2.onOrderChangedCallback += UpdateUI;
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < order2.OrderListP2.Count)
            {
                slots[i].AddItem(order2.OrderListP2[i]);
                //Debug.Log("Adding Item to OrderListP2UI");
            }
            else
                slots[i].ClearSlot();
        }
    }
}
