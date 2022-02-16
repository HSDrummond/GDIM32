using UnityEngine;
using UnityEngine.UI;

public class Inventory1Slot : MonoBehaviour
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
