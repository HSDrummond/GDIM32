using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The class has a single responsibility of handling pickups
// When the object is pickable or picked, it will notify other systems to take actions
//          - if picked notify the Inventory to save item, and follow player
//          - if picked it could notify the sound manager to display a sound
//          - if pickable it could also notify the UI to display a label {'E'}

public delegate void PickUpDelegate(GameObject gameobject);

public class PickUp : MonoBehaviour
{
    // Here you create a new Inventory for every item that can be picked.
    // Instead of having one Inventory that you access when needed. So I commented it out.
    // public Inventory Following { get; set; }

    private bool pickUpAllowed;
    // a delegate that will observ the pickup
    public static event PickUpDelegate pickupEvent;


    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            // notifies all the subscribing classes, right now there is only one: Inventory
            pickupEvent.Invoke(gameObject);
            PickUpItem();
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
        // This doesn't do anything right now,
        // but could for example change the size of the picked item or anything else.

        // Destroy(gameObject);
        // gameObject.transform.SetParent(player.transform, false);
        // Following.Follow(gameObject);
    }


}
