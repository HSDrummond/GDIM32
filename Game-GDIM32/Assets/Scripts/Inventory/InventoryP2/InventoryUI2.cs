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
        slots[0].ClearSlot();
        slots[1].ClearSlot();
        slots[2].ClearSlot();

        for (int i = 0; i < inventory.items.Count; ++i)
        {
            if (inventory.items[i] != null)
            {
                slots[i].AddItem(inventory.items[i]);
            }
        }

    }
}
