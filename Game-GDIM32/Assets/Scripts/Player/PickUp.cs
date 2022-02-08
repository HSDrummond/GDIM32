using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The class has a single responsibility of handling pickups
// When the object is pickable or picked, it will notify other systems to take actions
//          - if picked notify the Inventory to save item, and follow player
//          - if picked it could notify the sound manager to display a sound
//          - if pickable it could also notify the UI to display a label {'E'}

public delegate void PickUpDelegate(GameObject gameObject);

public class PickUp : MonoBehaviour
{

    private bool pickUpAllowed;
    public Sprite icon;

    // a delegate that will observ the pickup
    public static event PickUpDelegate PickupEvent;


    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            // notifies all the subscribing classes, right now there is only one: Inventory
            PickupEvent.Invoke(gameObject);
            PickUpItem();

            pickUpAllowed = false;

        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pickUpAllowed = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pickUpAllowed = false;
        }
    }

    private void PickUpItem()
    {
       //Does Nothing Yet
    }


}
