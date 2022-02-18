using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public static bool gameOver = false;
    [SerializeField] private GameObject winScreen;

    void Update()
    {
        if (gameOver)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        winScreen.SetActive(true);
    }


    public void LoadMenu()
    {
        Time.timeScale = 1f;
        winScreen.SetActive(false);
        gameOver = false;
        SceneManager.LoadScene(0);
    }
}
