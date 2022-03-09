using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderScoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboard;

    public void UpdateScoreboard(int score)
    {
        scoreboard.text = "completed: " + score.ToString();
    }
}
