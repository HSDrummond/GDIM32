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

    private bool OrderActive = false;

    public void Update()
    {
        if(OrderActive == false)
        {
            GenerateOrder();
            OrderActive = true;
        }
        else if(OrderActive == true)
        {
            if(CheckOrder() == true)
            {
                //Need to implimetn interaction

                //ClearInventory
                ClearOrder();
                OrderActive = false;
                //OrderCompleted++
            }
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
    }

    public void ClearOrder()
    {
        OrderListP1.Clear();
        Debug.Log("Clearing Order");
        if (onOrderChangedCallback != null)
        {
            onOrderChangedCallback.Invoke();
        }
    }
    public bool CheckOrder()
    {
        Debug.Log("Checking Simularity Order");
        List<GameObject> CheckInventory = inventory1.GetInventory();

        //MUST CHANGE LIST OF GAME OBJECTS TO LIST OF NAMES
        //- For each thing in inventory script
        //- inventory[current_index].name
        //- For each thing in order script 
        //- order[current_index].name
        //CHANGE INVENTORY LIST IN INVENTORY SCRIPT
        //COPY ALL THINGS FOR PLAYER 2
        if (CompareLists(OrderListP1, CheckInventory))
        {
            Debug.Log("They Equal");
            return true;
            
        }
        else
        {
            Debug.Log("They wrong fool");
            return false;
        }
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
