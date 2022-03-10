//Inventory2: Duncan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Inventory2 : MonoBehaviour
{
    public static Inventory2 instance;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback = null;

    public int space = 3;

    public List<GameObject> items = new List<GameObject>();

    private PlayerControls playerControls;

    [SerializeField]
    private AudioSource pickUpSound;

    [SerializeField]
    private AudioSource dropSound;

    private void Awake()
    {
        instance = this;

        playerControls = new PlayerControls();
        playerControls.Player2.PickUp.performed += context =>
        {
            if (context.interaction is HoldInteraction)
            {
                PerformRemoval2();
                dropSound.Play();
            }
        };
    }

    #region Notifications
    private void OnEnable()
    {
        PickUp.PickupEvent2 += Add;
        playerControls.Enable();
    }
    // Unsubscribe for the pickup notification
    private void OnDisable()
    {
        PickUp.PickupEvent2 -= Add;
        playerControls.Disable();
    }
    #endregion

    public void Add(GameObject item)
    {
        pickUpSound.Play();

        if (items.Count >= space)
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

    public void ClearInventory2()
    {
        items.Clear();
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

    }

    private void PerformRemoval2()
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
