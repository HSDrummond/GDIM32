//InventoryUI1: Hunter
using UnityEngine;
using System;

public class InventoryUI1 : MonoBehaviour
{
    public GameObject Inven_Panel;

    Inventory1 inventory;

    Inventory1Slot[] slots;

 

    void Start()
    {
        inventory = Inventory1.instance;
        //inventory = gameObject.GetComponent<Inventory>();
        inventory.onItemChangedCallback += UpdateUI;

        slots = Inven_Panel.GetComponentsInChildren<Inventory1Slot>();
    }

    void UpdateUI()
    {
        //Debug.Log(inventory.items.Count);
        /*
        if (inventory.items.Count == 0)
        {
            foreach (var x in slots)
            {
                x.ClearSlot();
            }
        }
        else
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < inventory.items.Count)
                {
                    slots[i].AddItem(inventory.items[i]);
                    //Debug.Log("Adding Item to Inventory1UI");
                }
                else
                    slots[i].ClearSlot();
            }
        }
        */


        slots[0].ClearSlot();
        slots[1].ClearSlot();
        slots[2].ClearSlot();

        for (int i = 0; i < inventory.items.Count; ++i)
        {
            if (inventory.items[i] != null)
            {
                slots[i].AddItem(inventory.items[i]);
            }
        }

    }
}
