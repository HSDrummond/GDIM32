using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> croplist = new List<GameObject>();

    public float respawnTimer = 1.0f;
    private float delayTime = 0.0f;
    #region Notifications
    private void OnEnable()
    {
        PickUp.PickupEvent += Respawn;
    }
    // Unsubscribe for the pickup notification
    private void OnDisable()
    {
        PickUp.PickupEvent -= Respawn;
    }
    #endregion

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

    public void Respawn(GameObject item)
    {
            respawnTimer += Time.deltaTime;
            if (respawnTimer > delayTime)
            {
                var newObject = Instantiate(item, transform.position,
                transform.rotation);
                respawnTimer = 0.0f;
            }
        
    }

}
