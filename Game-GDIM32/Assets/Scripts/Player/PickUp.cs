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

    private bool pickUpAllowed1;
    private bool pickUpAllowed2;
    public Sprite icon;

    // a delegate that will observ the pickup
    public static event PickUpDelegate PickupEvent1;
    public static event PickUpDelegate PickupEvent2;

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Player1.PickUp.performed += _ => PerformPickup1();
        playerControls.Player2.PickUp.performed += _ => PerformPickup2();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void PerformPickup1()
    {
        if (pickUpAllowed1)
        {
            // notifies all the subscribing classes, right now there is only one: Inventory
            PickupEvent1.Invoke(gameObject);

            pickUpAllowed1 = false;

        }
    }

    private void PerformPickup2()
    {
        if (pickUpAllowed2)
        {
            // notifies all the subscribing classes, right now there is only one: Inventory
            PickupEvent2.Invoke(gameObject);

            pickUpAllowed2 = false;

        }
    }

    private void Update()
    {
       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") && (collision.GetComponent<Inventory1>().items.Count < collision.GetComponent<Inventory1>().space))
        {
            pickUpAllowed1 = true;
        }
        if (collision.gameObject.CompareTag("Player2") && (collision.GetComponent<Inventory2>().items.Count < collision.GetComponent<Inventory2>().space))
        {
            pickUpAllowed2 = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            pickUpAllowed1 = false;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            pickUpAllowed2 = false;
        }
    }
}
