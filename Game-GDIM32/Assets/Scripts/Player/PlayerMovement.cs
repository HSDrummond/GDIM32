using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// has a single responsibility to control player 
public class PlayerMovement : MonoBehaviour
{
    // Fields that you access and set in the Unity Editor can be private and serialized
    
    public int m_PlayerNumber = 0;

    [SerializeField]
    private float moveSpeed = 15f;

    [SerializeField]
    private Rigidbody2D rb;

    private Vector2 movement;

    private void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //Physics
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    

}
