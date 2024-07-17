using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    public Text timeText;
    public Text dateText;
    private float elapsedTime = 0f;
    public bool timerStarted = false;
    private int startDay = 1;
    private float timeScale = 1f;
    public CameraFade cameraFade;
    public PlayerStateInfo playerStateInfo;
    public PlayerController playerController;
    private bool isChangeInfo = false;
    private void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (!timerStarted)
            return;

        UpdateTimeText();

        if(Input.GetKeyDown(KeyCode.M))
        {
            SpendHours(4);
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
    public void SpendHours(int timePassed) // 원하는 시간/2를 대입
    {
        playerController.SetMoveable(false);
        if (timeScale == 1f)
        {
            if(timePassed > 6)
            {
                PlayerStateInfo playerStateInfo = FindObjectOfType<PlayerStateInfo>();
                playerStateInfo.ChangeState(PlayerState.Sleeping);
                cameraFade.FadeOut(1f);
            }
            float originalTimeScale = Time.timeScale; 
            Time.timeScale = 60f; 

            float totalTimePassed = timePassed * 1800;

            StartCoroutine(CountDown(totalTimePassed, originalTimeScale));
        }
    }

    private IEnumerator CountDown(float totalTimePassed, float originalTimeScale)
    {
        PlayerStateInfo playerStateInfo = FindObjectOfType<PlayerStateInfo>();

        while (totalTimePassed > 0)
        {
            float deltaTime = Time.deltaTime * Time.timeScale;
            elapsedTime += deltaTime;
            totalTimePassed -= deltaTime;

            UpdateTimeText();

            yield return null;
        }
        Time.timeScale = originalTimeScale;
        if (playerStateInfo.isSleeping)
        {
            playerStateInfo.WakeUp();
        }
        playerController.SetMoveable(true);
    }
    public void UpdateTimeText()
    {
        int totalMinutes = Mathf.FloorToInt(elapsedTime / 60);
        int totalHours = totalMinutes / 60;
        int days = totalHours / 24 + startDay;

        int hours = totalHours % 24;
        int minutes = totalMinutes % 60;
        int textMinutes = minutes;
        if (minutes < 30)
        {
            textMinutes = 0;
            isChangeInfo = false;
        }
        else if (minutes >= 30 && !isChangeInfo)
        {
            UpdatePlayInfo();
            isChangeInfo = true;
            textMinutes = 30;
        }
        else
        {
            textMinutes = 30;
        }

        timeText.text = string.Format("{0:D2}:{1:D2}", hours, textMinutes);
        dateText.text = string.Format("Day {0}", days);
    }
    private void UpdatePlayInfo()
    {
        playerStateInfo.Hunger += Mathf.RoundToInt(5);
        if (!playerStateInfo.isSleeping)
        {
            playerStateInfo.Fatigue += Mathf.RoundToInt(5);
        }
    }
}