using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public enum DisaesterList
{
    Lava,
    VolcanicBomb,
    Earthquake,
}

public enum DisaesterEffectList
{
    VolcanicAsh,
    VolcanicGas
}

public class Disaester : MonoBehaviour
{
    public GameTimer elapsedTime;
    public List<float> eventTimes = new List<float>();
    private bool earthquakeTriggered = false;
    private bool disasterTriggered;
    private float cooldownTime = 1f;
    private float LavaCount = 0f;
    public PlayerStateInfo playerStateInfo;
    private PlayerState currentState;
    public PlayerState CurrentState
    {
        get { return currentState; }
        private set { currentState = value; }
    }


    void Start()
    {
        eventTimes = new List<float> { 0, 4, 8, 12, 16, 20 };
        disasterTriggered = false;
    }

    void Update()
    {
        int hours = elapsedTime.GetHours();  
        int minutes = elapsedTime.GetMinutes(); 
        int days = elapsedTime.GetDays();   

        if (!earthquakeTriggered && days == 1 && hours == 8 && minutes == 0)
        {
            TriggerEarthquakeEvent();
            earthquakeTriggered = true;
        }
        if (!disasterTriggered && (days == 1 && hours == 20 && minutes == 0 ||
                                          (days >= 2 && days <= 3 && hours % 4 == 0 && minutes == 0) ||
                                          (days == 4 && hours == 12 && minutes == 0)))
        {
            disasterTriggered = true;
            DisaesterEvent();
        }
    }

    void DisaesterEvent()
    {
        int result = Random.Range(0, 2);
        switch (result)
        {
            case 0:
                TriggerEarthquakeEvent();
                break;
            case 1:
                TriggerVolcanicEvent();
                break;
        }
        StartCoroutine(ResetDisasterTrigger());
    }

    void TriggerEarthquakeEvent()
    {
        // 지진 이벤트 로직
        if(currentState != PlayerState.Crouching)
        {
            playerStateInfo.TakeDamage(20);
        }
        Debug.Log("Earthquake Event Triggered");
        earthquakeTriggered = false;
    }

    void TriggerVolcanicEvent()
    {
        //화산 폭발 클로즈업 카메라 및 UI 껐다 켜기
        int result = Random.Range(0, 10);
        if (result < 3)
        {
            TriggerLavaEvent();
        }
        else if(result >= 3)
        {
            TriggerVolcanicBombEvent();
        }
    }
    void TriggerLavaEvent()
    {
        LavaCount++;
        if ((LavaCount >= 5))
        {
            //용암이 흘러오는 로직
        }
        Debug.Log("Lava Event Triggered");
    }
    void TriggerVolcanicBombEvent()
    {
        //집 주변 랜덤한 위치에 화산탄 낙하
        Debug.Log("VolcanicBombEvent");
    }
    IEnumerator ResetDisasterTrigger()
    {
        yield return new WaitForSeconds(cooldownTime);
        disasterTriggered = false;
    }
}