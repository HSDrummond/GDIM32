//GameStateManager: Duncan/Clay/Kiana
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    //private SceneMaster sceneMaster;

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
        //sceneMaster = GetComponent<SceneMaster>();
        //Debug.Log(sceneMaster != null);

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
        ToGameplayScene();
    }
    public void TogglePauseGame()
    {
        // not paused
        if (state == GameState.PLAYING && state != GameState.GAMEOVER)
        {
            state = GameState.PAUSED;
            Time.timeScale = 0f;
            TogglePauseCanvas(true);
        }
        // paused
        else if (state == GameState.PAUSED && state != GameState.GAMEOVER)
        {
            state = GameState.PLAYING;
            Time.timeScale = 1f;
            TogglePauseCanvas(false);
        }
    }
    public void EndGame()
    {
        if (state == GameState.PAUSED)
        {
            TogglePauseCanvas(false);
        }

        state = GameState.GAMEOVER;
        ActivateGameOverCanvas();
    }
    public void ExitToMenu()
    {
        if (state == GameState.PAUSED)
        {
            DeactivateGameOverCanvas();
        }
        else if (state == GameState.GAMEOVER)
        {
            DeactivateGameOverCanvas();
        }
        ToMenuScene();
        state = GameState.MENU;
    }
    public void QuitApplication()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    #endregion

    #region scene stuff
    public void ToGameplayScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void TogglePauseCanvas(bool b)
    {
        GameObject.FindGameObjectWithTag("winnerObj").GetComponent<DecideWinner>().pauseCanvas.SetActive(b);
    }

    public void ActivateGameOverCanvas()
    {

        GameObject.FindGameObjectWithTag("winnerObj").GetComponent<DecideWinner>().gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DeactivateGameOverCanvas()
    {
        Time.timeScale = 1f;
        GameObject.FindGameObjectWithTag("winnerObj").GetComponent<DecideWinner>().gameOverCanvas.SetActive(false);
    }


    public void ToMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    #endregion
}
