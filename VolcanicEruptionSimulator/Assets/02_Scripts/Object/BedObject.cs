using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BedObject : MonoBehaviour ,IInteractable, IEffectable
{
    public UnityEvent onSleep;
    public void Interact()
    {
        onSleep.Invoke();
    }
    public void EffectToPlayer(PlayerStateInfo playerStateInfo)
    {
        if (playerStateInfo.Fatigue >= 80)
        {
            playerStateInfo.Fatigue -= 80;
        }
        else
        {
            playerStateInfo.Fatigue = 0;
        }
    }
}
