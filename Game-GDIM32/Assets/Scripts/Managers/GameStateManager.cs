using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : GenericSingletonClass<GameStateManager>
{

    public PlayerManager[] m_Players;
    public GameObject m_PlayerPrefab;
    public CameraControl m_CameraControl;

    private void Start()
    {
        SpawnPlayers();
        SetCameraTargets();
    }

    void Update()
    {

        // WIN CONDITION
        if (PlayersStats.p1_item_count >= 5 || PlayersStats.p2_item_count >= 5)
        {
            WinScreen.gameOver = true;
        }
    }

    private void SpawnPlayers()
    {
        for (int i = 0; i < m_Players.Length; i++)
        {
            m_Players[i].m_Instance =
                Instantiate(m_PlayerPrefab, m_Players[i].m_SpawnPoint.position, m_Players[i].m_SpawnPoint.rotation) as GameObject;
            m_Players[i].m_PlayerNumber = i + 1;
            m_Players[i].Setup();
        }
    }


    private void SetCameraTargets()
    {
        Transform[] targets = new Transform[m_Players.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = m_Players[i].m_Instance.transform;
        }

        m_CameraControl.m_Targets = targets;
    }
}
