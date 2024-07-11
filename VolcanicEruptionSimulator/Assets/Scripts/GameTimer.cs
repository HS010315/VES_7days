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

        // ���� ��� �ð��� �� ������ ��ȯ
        gameSec = elapsedGameTime * 60f;

        // 1�ð�(60��)���� ��� �ð� ���
        if (gameSec >= 60 &&gameSec % 60 == 0)
        {
            Debug.Log(gameSec + "�� ���");
        }

        // gameDay UI ǥ��
        // gameHour UI ǥ��
        int intervalsPassed = Mathf.FloorToInt(gameSec / 1800f);
        if (gameSec >= 1800 && intervalsPassed % 2 == 0)
        {
            if (resetCount < intervalsPassed)
            {
                resetCount = intervalsPassed;

                // gameMin UI�� �ð� ǥ�� ó��
                Debug.Log(resetCount * 1800 + "�� ���: resetCount = " + resetCount);
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
            Debug.Log(gameHour + "��");
            if (gameHour >= 24)
            {
                gameHour = 0;
                gameDay++;
                Debug.Log(gameDay + "��");
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
