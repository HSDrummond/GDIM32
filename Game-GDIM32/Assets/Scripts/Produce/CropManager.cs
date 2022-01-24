using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> croplist = new List<GameObject>();

    void Start()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SwapPoints");

        CropSpawner[] Crops = Resources.LoadAll<CropSpawner>("Crops");

        foreach(GameObject point in spawnPoints)
        {
            //go through each child of thing with tag "SwapPoints" 
                //instantiate a random crop into all the children
        }
    }

}
