using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizePowerUpP2 : MonoBehaviour
{

    public float multiplier = 1.4f;

    public GameObject pickupEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        player.transform.localScale *= multiplier;

        Destroy(gameObject);
    }

}