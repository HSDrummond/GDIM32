using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int m_PlayerNumber = 0;

    public float moveSpeed = 15f;

    public Rigidbody2D rb;

    //public Transform inven_Prefab;

    Vector2 movement;

    public List<Transform> m_Inventory;

    private void Start()
    {
        m_Inventory = new List<Transform>();
        m_Inventory.Add(this.transform);
    }

    private void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        for (int i = m_Inventory.Count - 1; i > 0; i--)
        {
            m_Inventory[i].position = m_Inventory[i - 1].position;
        }
        //Physics
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

   /* public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crop"))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Follow();
            }
           
        }
    }*/

    public void Follow(GameObject gameObject)
    {

        //Transform follower = Instantiate(this.inven_Prefab);
        gameObject.transform.position = m_Inventory[m_Inventory.Count - 1].position;

        m_Inventory.Add(gameObject.transform);
    }

}
