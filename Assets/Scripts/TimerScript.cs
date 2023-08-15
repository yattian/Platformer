using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timerText; // Reference to UI Text to display the time.

    private float startTime;
    private bool isRunning = false;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (!isRunning) return;

        float timePassed = Time.time - startTime;
        string minutes = ((int)timePassed / 60).ToString("00");
        string seconds = (timePassed % 60).ToString("00");
        string milliseconds = ((int)(timePassed * 100) % 100).ToString("00");

        timerText.text = "Timer " + minutes + ":" + seconds + "." + milliseconds;
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public float GetTimeElapsed()
    {
        return Time.time - startTime;
    }
}
