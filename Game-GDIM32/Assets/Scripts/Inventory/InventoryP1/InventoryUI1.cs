using UnityEngine;

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
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
                Debug.Log("Adding Item to Inventory1UI");
            }
            else
                slots[i].ClearSlot();
        }
    }
}
