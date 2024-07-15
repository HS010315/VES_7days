using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    public Text timeText;
    public Text dateText;

    private float gameTime = 60f;
    private float elapsedTime = 0f;
    public bool timerStarted = false;
    private int startDay = 1;

    private float timeScale = 1f;

    private void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (!timerStarted)
            return;

        elapsedTime += Time.deltaTime * gameTime * timeScale;

        UpdateTimeText();

        if(Input.GetKeyDown(KeyCode.M))
        {
            SleepForHours(4);
        }
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
    public void SleepForHours(int timePassed)
    {
        if (timeScale == 1f)
        {
            float originalTimeScale = Time.timeScale; 
            Time.timeScale = 60f; 

            float totalTimePassed = timePassed * 3600;

            StartCoroutine(CountDown(totalTimePassed, originalTimeScale));
        }
    }

    private IEnumerator CountDown(float totalTimePassed, float originalTimeScale)
    {
        while (totalTimePassed > 0)
        {
            float deltaTime = Time.deltaTime * Time.timeScale;
            elapsedTime += deltaTime;
            totalTimePassed -= deltaTime;

            UpdateTimeText();

            yield return null;
        }

        Time.timeScale = originalTimeScale;
    }
    public void UpdateTimeText()
    {
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
}