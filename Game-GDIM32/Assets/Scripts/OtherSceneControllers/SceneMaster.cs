using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    public bool paused = false;
    private DecideWinner winnerDecider;

    #region functions for switching scenes
    public void ToGameplayScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void TogglePauseCanvas(bool b)
    {
        winnerDecider.TogglePauseCanvas(b);
    }

    public void ActivateGameOverCanvas()
    {
        winnerDecider.ToggleGameOverCanvas(true);
        Time.timeScale = 0f;
    }

    public void DeactivateGameOverCanvas()
    {
        Time.timeScale = 1f;
        winnerDecider.ToggleGameOverCanvas(false);
    }

    public void ToMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    #endregion
}
