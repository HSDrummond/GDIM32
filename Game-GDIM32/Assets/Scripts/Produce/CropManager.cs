using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> croplist = new List<GameObject>();

    void Start()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");

        //CropSpawner[] Crops = Resources.LoadAll<CropSpawner>("Crops");

        foreach(GameObject point in spawnPoints)
        {
            foreach (Transform child in transform)
            {
                GameObject currentEntity = Instantiate(croplist[0], child.position, Quaternion.identity);
            }
            //go through each child of thing with tag "SwapPoints" 
                //instantiate a random crop into all the children
        }
    }

}
