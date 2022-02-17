using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Inventory1 : MonoBehaviour
{

    public static Inventory1 instance;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback = null;

    public int space = 3;

    public List<GameObject> items = new List<GameObject>();

    private PlayerControls playerControls;

    private void Awake()
    {
        instance = this;

        playerControls = new PlayerControls();
        playerControls.Player1.PickUp.performed += context =>
        {
            if (context.interaction is HoldInteraction)
            {
                PerformRemoval1();
            }
        };
    }

    #region Notifications
    private void OnEnable()
    {
        PickUp.PickupEvent1 += Add;
        playerControls.Enable();
    }
    // Unsubscribe for the pickup notification
    private void OnDisable()
    {
        PickUp.PickupEvent1 -= Add;
        playerControls.Disable();
    }
    #endregion

    public void Add(GameObject item)
    {
        if(items.Count >= space)
        {
            return;
        }


        item.name = item.name.Replace("(Clone)", "");
        //Debug.Log(item.name);
        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
            //Debug.Log("Invoking callback");
        }


    }

    public void ClearInventory1()
    {
        items.Clear();
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        
    }

    private void PerformRemoval1()
    {
        if (items.Count > 0)
        {
            items.RemoveAt(items.Count - 1);
        }
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        Debug.Log("removal performed");
    }
}
