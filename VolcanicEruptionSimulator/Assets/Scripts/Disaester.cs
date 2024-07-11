using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

using Random = UnityEngine.Random;

public enum DisaesterList
{
    Lava,
    VolcanicBomb,
    Earthqauke,
}
public enum DisaesterEffectList
{
    VolcanicAsh,
    VolcanicGas
}

public class Disaester : MonoBehaviour
{
    public GameTimer gameTimer;
    public List<float> eventTimes = new List<float>();
    void Start()
    {
        eventTimes = new List<float> { 0, 4, 8, 12, 16, 20 };
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var eventTimes in eventTimes)
        {
            if(eventTimes == gameTimer.gameHour)
            {
                DisaesterEvent();
            }
        }
    }
    void DisaesterEvent()
    {
        int result = Random.Range(1, Enum.GetValues(typeof(DisaesterList)).Length);
        switch (result)
        {
            case 1:
            //용암 이벤트
                break;
            case 2:
                //화산탄 이벤트
                break;
            case 3:
                //지진 이벤트
                break;     
        }

    }
}
