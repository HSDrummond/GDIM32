using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform Inven_Panel_P1;

    //public Transform Inven_Panel_P2;

    Inventory inventory;

    InventorySlot[] slotsP1;

    //InventorySlot[] slotsP2;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slotsP1 = Inven_Panel_P1.GetComponentsInChildren<InventorySlot>();

        //slotsP2 = Inven_Panel_P2.GetComponentsInChildren<InventorySlot>();

    }


    void Update()
    {
      
    }

    void UpdateUI()
    {
        Debug.Log("Calling UpdateUI");
        for(int i = 0; i < slotsP1.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slotsP1[i].AddItem(inventory.items[i]);
                Debug.Log("Adding Item to Inventory");
            }
            else
                slotsP1[i].ClearSlot();
        }


    }

}
