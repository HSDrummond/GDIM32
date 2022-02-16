using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
//GenericSingletonClass<GameStateManager>
{
    public PlayerManager[] m_Players;
    public GameObject m_PlayerPrefab;
    public CameraControl m_CameraControl;

    [SerializeField]
    private List<string> m_Levels = new List<string>();
    [SerializeField]
    private string m_TitleSceneName;

    private static GameStateManager _instance;

    public enum GAMESTATE
    {
        MENU,
        PLAYING,
        PAUSED,
        GAMEOVER
    }

    public static GAMESTATE m_State;

    private void Start()
    {
        //SpawnPlayers();
        //SetCameraTargets();
    }

    private void Awake()
    {
        SpawnPlayers();
        SetCameraTargets();

        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }
    }

    public static void NewGame()
    {
        m_State = GAMESTATE.PLAYING;
        if(_instance.m_Levels.Count > 0)
        {
            SceneManager.LoadScene(_instance.m_Levels[0]);
        }
    }

    public static void QuitToTitle()
    {
        m_State = GAMESTATE.MENU;
        SceneManager.LoadScene(_instance.m_TitleSceneName);
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


    private void CheckTimeLoss()
    {
        if (Timer.currentTime == 0)
        {
            SceneManager.LoadScene(_instance.m_TitleSceneName);
        }
    }

    /* public static void TogglePause()
     {
         if(m_State == GAMESTATE.PLAYING)
         {
             m_State = GAMESTATE.PAUSED;
             Time.timeScale = 0;
         }
         else if(m_State == GAMESTATE.PAUSED)
         {
             m_State = GAMESTATE.PLAYING;
             Time.timeScale = 1;
         }
     }*/
}




/*
    

    void Update()
    {
      //Debug.Log(PlayersStats.p1_item_count);
        // WIN CONDITION
        if (PlayersStats.p1_item_count >= 5 || PlayersStats.p2_item_count >= 5)
        {
            
            WinScreen.gameOver = true;
        }
        CheckTimeLoss();

        

    }

  
*/
