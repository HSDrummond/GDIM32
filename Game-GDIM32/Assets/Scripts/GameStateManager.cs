using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    private SceneMaster sceneMaster;

    private void Awake()
    {
        // instance
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        // equip scene master
        sceneMaster = GetComponent<SceneMaster>();
        Debug.Log(sceneMaster);

        // begin states
        StartApplication();
    }

    public GameState state;

    public enum GameState
    {
        MENU,
        PLAYING,
        PAUSED,
        GAMEOVER
    }

    #region functions for switching states
    private void StartApplication()
    {
        state = GameState.MENU;
    }
    public void StartNewGame()
    {
        state = GameState.PLAYING;
        sceneMaster.ToGameplayScene();
    }
    public void TogglePauseGame()
    {
        // not paused
        if (state == GameState.PLAYING)
        {
            state = GameState.PAUSED;
            sceneMaster.TogglePauseCanvas(true);
        }
        // paused
        else if (state == GameState.PAUSED)
        {
            state = GameState.PLAYING;
            sceneMaster.TogglePauseCanvas(false);
        }
    }
    public void EndGame()
    {
        state = GameState.GAMEOVER;
        sceneMaster.ActivateGameOverCanvas();
    }
    public void ExitToMenu()
    {
        if (state == GameState.PAUSED)
        {
            sceneMaster.DeactivateGameOverCanvas();
        }
        else if (state == GameState.GAMEOVER)
        {
            sceneMaster.DeactivateGameOverCanvas();
        }
        sceneMaster.ToMenuScene();
        state = GameState.MENU;
    }
    public void QuitApplication()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    #endregion
}
