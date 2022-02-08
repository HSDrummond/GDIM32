using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    #region Singleton

    public static Inventory instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 3;

    public List<GameObject> items = new List<GameObject>();

    #region Notifications
    private void OnEnable()
    {
        PickUp.PickupEvent += Add;
    }
    // Unsubscribe for the pickup notification
    private void OnDisable()
    {
        PickUp.PickupEvent -= Add;
    }
    #endregion

    public void Add(GameObject item)
    {
        if(items.Count >= space)
        {
            return;
        }

        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
            Debug.Log("Invoking callback");
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
