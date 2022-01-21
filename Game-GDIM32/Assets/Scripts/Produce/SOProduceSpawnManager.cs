using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Product", menuName = "Crop/Animal")]
public class SOProduceSpawnManager : ScriptableObject
{
    public string prefabName;

    public int numberOfPrefabsToCreate;
    public Vector3[] spawnPoints;

    public bool isCrop;
    public bool isHarvisted;
}
