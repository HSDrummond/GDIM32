using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    public bool paused = false;
    private DecideWinner winnerObj;
    //private GameObject pauseCanvas;

    #region functions for switching scenes
    public void ToGameplayScene()
    {
        SceneManager.LoadScene("Main");
        winnerObj = FindObjectOfType<DecideWinner>();
        //pauseCanvas = FindObjectOfType<DecideWinner>().pauseCanvas;
    }

    public void TogglePauseCanvas(bool b)
    {
        winnerObj.TogglePauseCanvas(b);
    }

    public void ActivateGameOverCanvas()
    {
        winnerObj.ToggleGameOverCanvas(true);
        Time.timeScale = 0f;
    }

    public void DeactivateGameOverCanvas()
    {
        Time.timeScale = 1f;
        winnerObj.ToggleGameOverCanvas(false);
    }
    

    public void ToMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    #endregion
}
