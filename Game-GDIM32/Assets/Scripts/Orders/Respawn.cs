//Respawn: Duncan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private float respawnTime = 5;
    private float respawnTimer = 0;
    private bool startRespawn = false;
    private bool respawnDone = false;

    public void StartRespawnTimer()
    {
        startRespawn = true;
    }

    public float CheckTimer()
    {
        return respawnTimer;
    }

    public bool CheckRespawn()
    {
        return respawnDone;
    }

    private void Update()
    {
        if (startRespawn)
        {
            respawnTimer += Time.deltaTime;
        }

        if (respawnTimer >= respawnTime)
        {
            startRespawn = false;
            respawnTimer = 0;
            respawnDone = true;
        }
    }
}
