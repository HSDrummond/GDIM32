using UnityEngine;

public class InventoryUI2 : MonoBehaviour
{
    public GameObject Inven_Panel;

    Inventory2 inventory;

    Inventory2Slot[] slots;



    void Start()
    {
        inventory = Inventory2.instance;
        //inventory = gameObject.GetComponent<Inventory>();
        inventory.onItemChangedCallback += UpdateUI;

        slots = Inven_Panel.GetComponentsInChildren<Inventory2Slot>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
                Debug.Log("Adding Item to Inventory2UI");
            }
            else
                slots[i].ClearSlot();
        }
    }
}
