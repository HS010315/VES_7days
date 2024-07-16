using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaJObject : MonoBehaviour, IInteractable, IEffectable
{
    public void Interact()
    {
        Destroy(this.gameObject);
    }
    public void EffectToPlayer(PlayerStateInfo playerStateInfo)
    {
        if(playerStateInfo.Hp > 80)
        {
            playerStateInfo.Hp = 100;
        }
        else
        {
            playerStateInfo.Hp += 20;
        }
        //질병 없애는 로직
    }
}
