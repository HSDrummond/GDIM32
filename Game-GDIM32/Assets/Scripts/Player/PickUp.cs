using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private PlayerControls playerControls;
    private bool pickUp = false;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Player1.PickUp.performed += _ => PerformPickup();
        playerControls.Player2.PickUp.performed += _ => PerformPickup();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void PerformPickup()
    {
        pickUp = true;
    }

    private void Update()
    {
        if (pickUpAllowed && pickUp)
        {
            // notifies all the subscribing classes, right now there is only one: Inventory
            PickupEvent.Invoke(gameObject);

            pickUpAllowed = false;
            pickUp = false;

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
}
