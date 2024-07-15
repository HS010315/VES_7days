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

    void Start()
    {
        eventTimes = new List<float> { 0, 4, 8, 12, 16, 20 };
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

        if (days >= 1 && hours >= 20 && minutes == 0 && hours % 4 == 0)
        {
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
    }

    void TriggerEarthquakeEvent()
    {
        // 지진 이벤트 로직
        Debug.Log("Earthquake Event Triggered");
    }

    void TriggerVolcanicEvent()
    {
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
        Debug.Log("Lava Event Triggered");
    }
    void TriggerVolcanicBombEvent()
    {
        Debug.Log("VolcanicBombEvent");
    }
}