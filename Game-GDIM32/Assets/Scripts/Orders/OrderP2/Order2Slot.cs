//Order2Slot: Hunter/Duncan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order2Slot : MonoBehaviour
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
