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
        ResetGame();
        SceneManager.LoadScene(0);
    }

    private void ResetGame()
    {
        PlayersStats.p1_animal_count = 0;
        PlayersStats.p1_crop_count = 0;
        PlayersStats.p2_animal_count = 0;
        PlayersStats.p1_crop_count = 0;
        PlayersStats.p1_item_count = 0;
    }
}
