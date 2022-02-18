using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order2 : MonoBehaviour
{
    public static Order2 instance;

    private int completedOrders = 0;

    public delegate void OnOrderChanged();
    public OnOrderChanged onOrderChangedCallback = null;

    [SerializeField]
    private List<GameObject> Tier3Crops = new List<GameObject>();

    [SerializeField]
    private List<GameObject> Tier2Crops = new List<GameObject>();

    [SerializeField]
    private List<GameObject> Tier1Crops = new List<GameObject>();

    public List<GameObject> OrderListP2 = new List<GameObject>();

    Inventory2 inventory2;

    private bool OrderActive = false;


    private void Awake()
    {
        instance = this;
        Debug.Log(Inventory2.instance);
        inventory2 = Inventory2.instance;
    }

    public void Update()
    {
        if (OrderActive == false)
        {
            GenerateOrder();
            OrderActive = true;
        }
        else if (OrderActive == true)
        {
            // only checks if inventory is full
            if (inventory2.items.Count == inventory2.space)
            {
                if (CheckOrder() == true)
                {
                    //Need to implimetn interaction
                    inventory2.ClearInventory2();
                    ClearOrder();
                    OrderActive = false;
                    completedOrders += 1;
                }
            }
        }
    }

    public void GenerateOrder()
    {
        int randomT3Crop = Random.Range(0, Tier3Crops.Count);
        int randomT2Crop = Random.Range(0, Tier2Crops.Count);
        int randomT1Crop = Random.Range(0, Tier1Crops.Count);

        OrderListP2.Add(Tier3Crops[randomT3Crop]);
        OrderListP2.Add(Tier2Crops[randomT2Crop]);
        OrderListP2.Add(Tier1Crops[randomT1Crop]);

        if (onOrderChangedCallback != null)
        {
            onOrderChangedCallback.Invoke();
        }
    }

    public void ClearOrder()
    {
        OrderListP2.Clear();
        //Debug.Log("Clearing Order");
        if (onOrderChangedCallback != null)
        {
            onOrderChangedCallback.Invoke();
        }
    }
    public bool CheckOrder()
    {
        //Debug.Log("Checking Simularity Order");

        List<string> OrderListP2Names = new List<string>();
        List<string> inventory2Names = new List<string>();

        foreach (var x in OrderListP2)
        {
            OrderListP2Names.Add(x.name);
        }
        foreach (var x in inventory2.items)
        {
            inventory2Names.Add(x.name);
        }

        if (CompareLists(OrderListP2Names, inventory2Names))
        {

            //Debug.Log("They Equal");
            return true;

        }
        else
        {
            //Debug.Log("They wrong fool");
            return false;
        }
    }

    public int CheckCompletedOrders()
    {
        return completedOrders;
    }

    public static bool CompareLists<T>(List<T> aListA, List<T> aListB)
    {
        if (aListA == null || aListB == null || aListA.Count != aListB.Count)
            return false;
        if (aListA.Count == 0)
            return true;
        Dictionary<T, int> lookUp = new Dictionary<T, int>();
        // create index for the first list
        for (int i = 0; i < aListA.Count; i++)
        {
            int count = 0;
            if (!lookUp.TryGetValue(aListA[i], out count))
            {
                lookUp.Add(aListA[i], 1);
                continue;
            }
            lookUp[aListA[i]] = count + 1;
        }
        for (int i = 0; i < aListB.Count; i++)
        {
            int count = 0;
            if (!lookUp.TryGetValue(aListB[i], out count))
            {
                // early exit as the current value in B doesn't exist in the lookUp (and not in ListA)
                return false;
            }
            count--;
            if (count <= 0)
                lookUp.Remove(aListB[i]);
            else
                lookUp[aListB[i]] = count;
        }
        // if there are remaining elements in the lookUp, that means ListA contains elements that do not exist in ListB
        return lookUp.Count == 0;
    }
}
