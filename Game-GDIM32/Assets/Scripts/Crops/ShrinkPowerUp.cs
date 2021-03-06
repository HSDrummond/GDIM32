//ShrinkPowerUp Shiloh
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPowerUp : MonoBehaviour
{
    public float multiplier = 0.5f;
    public float duration = 4f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        player.transform.localScale *= multiplier;

        yield return new WaitForSeconds(duration);

        player.transform.localScale /= multiplier;

        //Destroy(gameObject);
    }

}
