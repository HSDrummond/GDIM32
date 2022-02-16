using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform Inven_Panel;

    Inventory inventory;

    InventorySlot[] slots;

 

    void Start()
    {
        //inventory = Inventory.instance;
        inventory = GetComponent<Inventory>();
        inventory.onItemChangedCallback += UpdateUI;

        slots = Inven_Panel.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
                Debug.Log("Adding Item to Inventory");
            }
            else
                slots[i].ClearSlot();
        }
    }
}
