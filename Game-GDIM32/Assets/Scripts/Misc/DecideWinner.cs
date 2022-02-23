using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecideWinner : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    [SerializeField] private Text winnerDisplay;

    [SerializeField] public GameObject pauseCanvas;
    [SerializeField] public GameObject gameOverCanvas;

    private bool gameOver = false;

    private void Update()
    {
        if (Timer.currentTime == 0 && !gameOver)
        {
            gameOver = true;
            GameStateManager.instance.EndGame();
            winnerDisplay.text = ReturnWinnerText();
        }
    }

    public string ReturnWinnerText()
    {
        if (player1.GetComponent<Order1>().CheckCompletedOrders() >
            player2.GetComponent<Order2>().CheckCompletedOrders())
        {
            return "Player 1 Wins!";
        }
        else if (player1.GetComponent<Order1>().CheckCompletedOrders() <
                 player2.GetComponent<Order2>().CheckCompletedOrders())
        {
            return "Player 2 Wins!";
        }
        else if (player1.GetComponent<Order1>().CheckCompletedOrders() ==
                  player2.GetComponent<Order2>().CheckCompletedOrders())
        {
            return "It's a Tie!";
        }
        return "something didn't work?";
    }
}
