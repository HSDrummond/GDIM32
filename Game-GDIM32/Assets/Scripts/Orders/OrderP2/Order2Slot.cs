//Order2Slot: Hunter/Duncan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order2Slot : MonoBehaviour
{
    public Image icon;

    GameObject item;

    public void AddItem(GameObject newItem)
    {
        item = newItem;

        icon.sprite = item.GetComponent<SpriteRenderer>().sprite;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
