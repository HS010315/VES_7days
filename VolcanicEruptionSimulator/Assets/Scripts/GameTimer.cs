using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float gameStartTime;
    public float gameSec = 0f;
    public int resetCount = 0;
    public float gameHour;
    public float gameDay;
    void Start()
    {
        gameStartTime = Time.time;
        gameHour = 8f;
        gameDay = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedGameTime = Time.time - gameStartTime;

        // 게임 경과 시간을 분 단위로 변환
        gameSec = elapsedGameTime * 60f;

        // 1시간(60분)마다 경과 시간 출력
        if (gameSec >= 60 &&gameSec % 60 == 0)
        {
            Debug.Log(gameSec + "분 경과");
        }

        // gameDay UI 표시
        // gameHour UI 표시
        int intervalsPassed = Mathf.FloorToInt(gameSec / 1800f);
        if (gameSec >= 1800 && intervalsPassed % 2 == 0)
        {
            if (resetCount < intervalsPassed)
            {
                resetCount = intervalsPassed;

                // gameMin UI에 시간 표시 처리
                Debug.Log(resetCount * 1800 + "분 경과: resetCount = " + resetCount);
                UpdateTime();
            }
        }
    }
    public void UpdateTime()
    {
        if(resetCount % 2 == 0)
        {
            resetCount = 0;
            gameHour++;
            Debug.Log(gameHour + "시");
            if (gameHour >= 24)
            {
                gameHour = 0;
                gameDay++;
                Debug.Log(gameDay + "일");
            }
        }
    }

    public void TimePassed(int i)
    {
        Time.timeScale = 0;
        gameHour += i;
        UpdateTime();
        Time.timeScale = 1;
    }
}
