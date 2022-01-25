using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public PlayerMovement Following { get; set; }

    private bool pickUpAllowed;

    [SerializeField]
    private GameObject player;

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
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
        //Destroy(gameObject);
        //gameObject.transform.SetParent(player.transform, false);


        //temporary to p1 for singleplayer
        PlayersStats.p1_item_count += 1;

        Following.Follow(gameObject);
    }


}
