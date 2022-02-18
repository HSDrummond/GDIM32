using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float currentTime;
    public float startingTime = 10f;

    [SerializeField] Text CountDownTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        DisplayTime(currentTime);

        if(currentTime <= 0)
        {
            currentTime = 0;
        }
    }

    void DisplayTime( float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        CountDownTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
