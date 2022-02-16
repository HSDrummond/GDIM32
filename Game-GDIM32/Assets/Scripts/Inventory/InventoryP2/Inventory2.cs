using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory2 : MonoBehaviour
{

    #region Singleton

    public static Inventory2 instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion


    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback = null;

    public int space = 3;

    public List<GameObject> items = new List<GameObject>();

    #region Notifications
    private void OnEnable()
    {
        PickUp.PickupEvent2 += AddToInv2;
    }
    // Unsubscribe for the pickup notification
    private void OnDisable()
    {
        PickUp.PickupEvent2 -= AddToInv2;
    }
    #endregion

    public void AddToInv2(GameObject item)
    {
        if (items.Count >= space)
        {
            return;
        }

        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
            Debug.Log("Invoking callback1");
        }

        item.SetActive(false);


    }

    public void Remove(GameObject item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        item.SetActive(true);


    }
}
