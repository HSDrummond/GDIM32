//GameOverScene: Kiana
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void LoadMenu()
    {
        GameStateManager.instance.ExitToMenu();
    }
}
