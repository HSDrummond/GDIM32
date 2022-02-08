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
            int randomCrop = Random.Range(0, croplist.Count);
            //Debug.Log("1st floop");

            foreach (Transform spawnPoint in patch.transform)
            {

                Instantiate(croplist[randomCrop], spawnPoint.position, Quaternion.identity);
                //Debug.Log("2nd floop");
            }
            croplist.RemoveAt(randomCrop);
            //Debug.Log("no repeats");
        }
    }

}
