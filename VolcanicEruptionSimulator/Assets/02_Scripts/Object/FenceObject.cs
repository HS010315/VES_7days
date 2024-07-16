using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FenceObject : MonoBehaviour , IInteractable
{
    public GameObject makeFense;
    public UnityEvent spendTime;
    void Interact()
    {
        makeFense.SetActive(true);
        spendTime.Invoke();
        this.gameObject.GetComponent<FenceObject>().enabled = false;
    }
}
