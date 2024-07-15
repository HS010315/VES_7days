using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    public Text timeText;
    public Text dateText;

    private float gameTime = 60f;
    private float elapsedTime = 0f;
    public bool timerStarted = false;
    private int startDay = 1;
    

    void Update()
    {
        if (!timerStarted)
            return;

        elapsedTime += Time.deltaTime * gameTime;

        int totalMinutes = Mathf.FloorToInt(elapsedTime / 60);
        int totalHours = totalMinutes / 60;
        int days = totalHours / 24 + startDay;

        int hours = totalHours % 24;
        int minutes = totalMinutes % 60;

        if (minutes < 30)
        {
            minutes = 0;
        }
        else
        {
            minutes = 30;
        }

        timeText.text = string.Format("{0:D2}:{1:D2}", hours, minutes);
        dateText.text = string.Format("Day {0}", days);
    }

    public void StartTimer()
    {
        elapsedTime = (8 * 60) * 60;
        timerStarted = true;
    }

    public int GetHours()
    {
        int totalMinutes = Mathf.FloorToInt(elapsedTime / 60);
        int totalHours = totalMinutes / 60;
        return totalHours % 24;
    }

    public int GetMinutes()
    {
        int totalMinutes = Mathf.FloorToInt(elapsedTime / 60);
        return totalMinutes % 60;
    }

    public int GetDays()
    {
        int totalMinutes = Mathf.FloorToInt(elapsedTime / 60);
        int totalHours = totalMinutes / 60;
        return totalHours / 24 + startDay;
    }
}