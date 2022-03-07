//Order1: Clay/Hunter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order1 : MonoBehaviour
{
    [SerializeField] OrderScoreboard scoreboard;

    public static Order1 instance;

    private int completedOrders = 0;

    public delegate void OnOrderChanged();
    public OnOrderChanged onOrderChangedCallback = null;

    [SerializeField]
    private List<GameObject> Tier3Crops = new List<GameObject>();

    [SerializeField]
    private List<GameObject> Tier2Crops = new List<GameObject>();

    [SerializeField]
    private List<GameObject> Tier1Crops = new List<GameObject>();

    public List<GameObject> OrderListP1 = new List<GameObject>();

    //Inventory1 inventory1;

    private bool OrderActive = false;


    private void Awake()
    {
        instance = this;
        //inventory1 = Inventory1.instance;
    }

    public void Update()
    {
        if(OrderActive == false)
        {
            GenerateOrder();
            OrderActive = true;
        }
        else if(OrderActive == true)
        {
            // only checks if inventory is full
            if (Inventory1.instance.items.Count == Inventory1.instance.space)
            {
                if (CheckOrder() == true)
                {
                    //Need to impliment interaction
                    Inventory1.instance.ClearInventory1();
                    //ClearInventory
                    ClearOrder();
                    OrderActive = false;
                    completedOrders += 1;
                    scoreboard.UpdateScoreboard(completedOrders);
                }
            }
        }
    }

    public void GenerateOrder()
    {
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
    }

    public void ClearOrder()
    {
        OrderListP1.Clear();
        //Debug.Log("Clearing Order");
        if (onOrderChangedCallback != null)
        {
            onOrderChangedCallback.Invoke();
        }
    }
    public bool CheckOrder()
    {
        //Debug.Log("Checking Simularity Order");

        List<string> OrderListP1Names = new List<string>();
        List<string> inventory1Names = new List<string>();

        foreach (var x in OrderListP1)
        {
            OrderListP1Names.Add(x.name);
        }
        foreach (var x in Inventory1.instance.items)
        {
            inventory1Names.Add(x.name);
        }

        if (CompareLists(OrderListP1Names, inventory1Names))
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

    
    public List<string> GetInven()
    {
        List<string> inventory1Names = new List<string>();

        foreach (var x in Inventory1.instance.items)
        {
            inventory1Names.Add(x.name);
        }

        return inventory1Names;
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
