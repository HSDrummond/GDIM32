//MainMenu: Kiana
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        GameStateManager.instance.StartNewGame();
    }

    public void QuitButton()
    {
        GameStateManager.instance.QuitApplication();
    }
}
