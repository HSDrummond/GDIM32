using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order1 : MonoBehaviour
{
    #region Singleton

    public static Order1 instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public delegate void OnOrderChanged();
    public OnOrderChanged onOrderChangedCallback = null;

    [SerializeField]
    private List<GameObject> Tier3Crops = new List<GameObject>();

    [SerializeField]
    private List<GameObject> Tier2Crops = new List<GameObject>();

    [SerializeField]
    private List<GameObject> Tier1Crops = new List<GameObject>();

    public List<GameObject> OrderListP1 = new List<GameObject>();

    Inventory1 inventory1;

    private bool OrderEmpty = true;

    public void Update()
    {
        if(OrderEmpty == true)
        {
            GenerateOrder();
        }
        else if(OrderEmpty == false)
        {
            CheckOrder();
        }
    }

    public void GenerateOrder()
    {
        inventory1 = GetComponent<Inventory1>();

        int randomT3Crop = Random.Range(0, Tier3Crops.Count);
        int randomT2Crop = Random.Range(0, Tier2Crops.Count);
        int randomT1Crop = Random.Range(0, Tier1Crops.Count);

        OrderListP1.Add(Tier3Crops[randomT3Crop]);
        OrderListP1.Add(Tier2Crops[randomT2Crop]);
        OrderListP1.Add(Tier1Crops[randomT1Crop]);

        if (onOrderChangedCallback != null)
        {
            onOrderChangedCallback.Invoke();
        }

        OrderEmpty = false;
    }
    public void CheckOrder()
    {
        //Compare Order and Inventory
        //ClearInventory
        //OrderEmpty = false;
        //OrderCompleted++
    }

}
