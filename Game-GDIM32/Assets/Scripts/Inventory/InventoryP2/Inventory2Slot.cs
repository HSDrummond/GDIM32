//Inventory2Slots: Clay
using UnityEngine;
using UnityEngine.UI;

public class Inventory2Slot : MonoBehaviour
{
    public Image icon;

    public void AddItem(GameObject newItem)
    {
        icon.sprite = newItem.GetComponent<PickUp>().icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
    }
}
