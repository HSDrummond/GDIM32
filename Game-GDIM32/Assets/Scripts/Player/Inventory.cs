using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages the picked items
public class Inventory : MonoBehaviour
{
    private List<Transform> m_Inventory;

    // hook the player in the editor
    [SerializeField]
    private GameObject player;


    // Subscribe for the pickup notification
    private void OnEnable()
    {
        PickUp.pickupEvent += AddToInventory;
    }
    // Unsubscribe for the pickup notification
    private void OnDisable()
    {
        PickUp.pickupEvent -= AddToInventory;
    }

    private void Start()
    {
        m_Inventory = new List<Transform>();
        m_Inventory.Add(player.transform);
    }

    private void FixedUpdate()
    { 
        for (int i = 0; i < m_Inventory.Count; i++)
        { 
            if(i != 0) // if not the player
            {
                // this will not follow the player but everyone would have the same position,
                // as if the player would carry the veggies. So you need to work on this more.
                m_Inventory[i].position = m_Inventory[i-1].position;
            }
        }
    }

    public void AddToInventory(GameObject gameObject)
    {
        //Transform follower = Instantiate(this.inven_Prefab);
        // gameObject.transform.position = m_Inventory[m_Inventory.Count - 1].position;
        m_Inventory.Add(gameObject.transform);
        
        if (gameObject.tag == "Crop")
        {
            PlayersStats.p1_crop_count += 1;
        }
        else if (gameObject.tag == "Animal")
        {
            PlayersStats.p1_animal_count += 1;
        }
        else
        {
            Debug.Log("No tag on target");
        }
    }
}
