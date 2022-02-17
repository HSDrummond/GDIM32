using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ActiveTier3Crops = new List<GameObject>();

    [SerializeField]
    private List<GameObject> ActiveTier2Crops = new List<GameObject>();

    [SerializeField]
    private List<GameObject> ActiveTier1Crops = new List<GameObject>();

    [SerializeField] private GameObject respawnTimer;
    private Dictionary<GameObject, GameObject> respawnTracker = new Dictionary<GameObject, GameObject>();

    #region Notifications
    private void OnEnable()
    {
        PickUp.PickupEvent1 += StartRespawn;
        PickUp.PickupEvent2 += StartRespawn;
    }
    // Unsubscribe for the pickup notification
    private void OnDisable()
    {
        PickUp.PickupEvent1 -= StartRespawn;
        PickUp.PickupEvent2 -= StartRespawn;
    }
    #endregion

    void Start()
    {
        #region T3CropSpawning
        GameObject[] T3spawnPatches = GameObject.FindGameObjectsWithTag("T3SpawnPatch");
        foreach (GameObject patch in T3spawnPatches)
        {
            int randomT3Crop = Random.Range(0, ActiveTier3Crops.Count);

            foreach (Transform spawnPoint in patch.transform)
            {

                Instantiate(ActiveTier3Crops[randomT3Crop], spawnPoint.position, Quaternion.identity);
            }
            ActiveTier3Crops.RemoveAt(randomT3Crop);
        }
        #endregion

        #region T2CropSpawning
        GameObject[] T2spawnPatches = GameObject.FindGameObjectsWithTag("T2SpawnPatch");
        foreach (GameObject patch in T2spawnPatches)
        {
            int randomT2Crop = Random.Range(0, ActiveTier2Crops.Count);

            foreach (Transform spawnPoint in patch.transform)
            {

                Instantiate(ActiveTier2Crops[randomT2Crop], spawnPoint.position, Quaternion.identity);
            }
            ActiveTier2Crops.RemoveAt(randomT2Crop);
        }
        #endregion

        #region T1CropSpawning
        GameObject[] T1spawnPatches = GameObject.FindGameObjectsWithTag("T1SpawnPatch");
        foreach (GameObject patch in T1spawnPatches)
        {
            int randomT1Crop = Random.Range(0, ActiveTier1Crops.Count);

            foreach (Transform spawnPoint in patch.transform)
            {

                Instantiate(ActiveTier1Crops[randomT1Crop], spawnPoint.position, Quaternion.identity);
            }
            ActiveTier1Crops.RemoveAt(randomT1Crop);
        }
        #endregion
    }


    public void StartRespawn(GameObject item)
    {
        item.GetComponent<SpriteRenderer>().enabled = false;
        item.GetComponent<Collider2D>().enabled = false;
        GameObject currentRespawnTimer = Instantiate(respawnTimer);
        respawnTracker.Add(item, currentRespawnTimer);

        respawnTracker[item].GetComponent<Respawn>().StartRespawnTimer();
    }
    //
    public void CheckRespawnTracker()
    {
        if (respawnTracker.Count > 0)
        {
            List<GameObject> finishedRespawnObjects = new List<GameObject>();

            foreach (var pair in respawnTracker)
            {
                Debug.Log("Timer: " + pair.Value.GetComponent<Respawn>().CheckTimer());

                if (pair.Value.GetComponent<Respawn>().CheckRespawn() == true)
                {
                    pair.Key.GetComponent<SpriteRenderer>().enabled = true;
                    pair.Key.GetComponent<Collider2D>().enabled = true;

                    finishedRespawnObjects.Add(pair.Key);
                }
            }

            foreach (var obj in finishedRespawnObjects)
            {
                respawnTracker.Remove(obj);
            }
        }
    }

    public void Update()
    {
        CheckRespawnTracker();
    }

}
