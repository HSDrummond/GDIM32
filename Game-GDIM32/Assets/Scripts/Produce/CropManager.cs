using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> croplist = new List<GameObject>();

    void Start()
    {
        GameObject[] spawnPatches = GameObject.FindGameObjectsWithTag("SpawnPatch");

        //CropSpawner[] Crops = Resources.LoadAll<CropSpawner>("Crops");

        foreach(GameObject patch in spawnPatches)
        {
            Debug.Log("1st floop");
            foreach (Transform spawnPoint in patch.transform)
            {
                Instantiate(croplist[0], spawnPoint.position, Quaternion.identity);
                Debug.Log("2nd floop");
            }
            //go through each child of thing with tag "SwapPoints" 
                //instantiate a random crop into all the children
        }
    }

}
