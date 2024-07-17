using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShowerObject : MonoBehaviour, IInteractable , IEffectable
{
    public WaterOnObject water;
    public UnityEvent spendTime;

    public void EffectToPlayer(PlayerStateInfo playerStateInfo)
    {
        if (playerStateInfo.Contamination == 100)
        {
            playerStateInfo.Contamination -= 100;
        }
        else
        {
            playerStateInfo.Contamination = 0;
        }
    }
    public void Interact()
    {
        water.currentWater -= 25;
        spendTime.Invoke();
    }
}
