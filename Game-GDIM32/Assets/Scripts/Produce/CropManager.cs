using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Tier3Crops = new List<GameObject>();

    [SerializeField]
    private List<GameObject> Tier2Crops = new List<GameObject>();

    [SerializeField]
    private List<GameObject> Tier1Crops = new List<GameObject>();

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
        #region T3CropSpawning
        GameObject[] T3spawnPatches = GameObject.FindGameObjectsWithTag("T3SpawnPatch");
        foreach (GameObject patch in T3spawnPatches)
        {
            int randomT3Crop = Random.Range(0, Tier3Crops.Count);

            foreach (Transform spawnPoint in patch.transform)
            {

                Instantiate(Tier3Crops[randomT3Crop], spawnPoint.position, Quaternion.identity);
            }
            Tier3Crops.RemoveAt(randomT3Crop);
        }
        #endregion

        #region T2CropSpawning
        GameObject[] T2spawnPatches = GameObject.FindGameObjectsWithTag("T2SpawnPatch");
        foreach (GameObject patch in T2spawnPatches)
        {
            int randomT2Crop = Random.Range(0, Tier2Crops.Count);

            foreach (Transform spawnPoint in patch.transform)
            {

                Instantiate(Tier2Crops[randomT2Crop], spawnPoint.position, Quaternion.identity);
            }
            Tier2Crops.RemoveAt(randomT2Crop);
        }
        #endregion

        #region T1CropSpawning
        GameObject[] T1spawnPatches = GameObject.FindGameObjectsWithTag("T1SpawnPatch");
        foreach (GameObject patch in T1spawnPatches)
        {
            int randomT1Crop = Random.Range(0, Tier1Crops.Count);

            foreach (Transform spawnPoint in patch.transform)
            {

                Instantiate(Tier1Crops[randomT1Crop], spawnPoint.position, Quaternion.identity);
            }
            Tier1Crops.RemoveAt(randomT1Crop);
        }
        #endregion
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
