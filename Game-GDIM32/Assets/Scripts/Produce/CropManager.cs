using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> croplist = new List<GameObject>();

    public float respawnTimer = 0.0f;
    private float delayTime = 5.0f;
    private bool StartTimer = false;
    private GameObject RespawningItem;

    #region Notifications
    private void OnEnable()
    {
        PickUp.PickupEvent += StartRespawn;
    }
    // Unsubscribe for the pickup notification
    private void OnDisable()
    {
        PickUp.PickupEvent -= StartRespawn;
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

    public void Respawn()
    {
        Debug.Log("Spawn");
        RespawningItem.SetActive(true);

    }

    public void StartRespawn(GameObject item)
    {

        RespawningItem = item;
        StartTimer = true;
        Debug.Log("Start Timer");

    }

    public void Update()
    {
        if (respawnTimer > delayTime)
        {
            Respawn();
            respawnTimer = 0.0f;
            StartTimer = false;

        }

        if (StartTimer == true)
        {
            respawnTimer += Time.deltaTime;
        }
    }

}
