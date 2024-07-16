using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodObject : MonoBehaviour, IInteractable, IEffectable
{
    public void Interact()
    {
        Destroy(this.gameObject);
    }
    public void EffectToPlayer(PlayerStateInfo playerStateInfo)
    {
        if(this.gameObject.CompareTag("Food"))
        {
            playerStateInfo.Hunger -= 40;
        }
        else if(this.gameObject.CompareTag("EmergencyFood"))
        {
            playerStateInfo.hunger -= 20;
        }
        else if(this.gameObject.CompareTag("CleanWater"))
        {
            playerStateInfo.Hunger -= 10;
        }
        else if(this.gameObject.CompareTag("Tea"))
        {
            playerStateInfo.Hunger -= 5;
            playerStateInfo.Panic -= 10;

        }
    }
}
