using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void Resume()
    {
        GameStateManager.instance.TogglePauseGame();
    }

    public void TogglePause()
    {
        GameStateManager.instance.TogglePauseGame();
    }

    public void LoadMenu()
    {
        GameStateManager.instance.ExitToMenu();
    }
}

