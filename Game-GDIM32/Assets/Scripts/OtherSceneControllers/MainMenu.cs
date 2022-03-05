//MainMenu: Kiana
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayPlayerButton()
    {
        GameStateManager.instance.StartNewPlayerGame();
    }

    public void PlayAIButton()
    {
        GameStateManager.instance.StartNewAIGame();
    }

    public void QuitButton()
    {
        GameStateManager.instance.QuitApplication();
    }
}
