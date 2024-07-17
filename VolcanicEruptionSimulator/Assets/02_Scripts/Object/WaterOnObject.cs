using UnityEngine;
using System.Collections;

public class WaterOnObject : MonoBehaviour, IInteractable
{
    public float maxWater = 100f;
    public float currentWater = 0f;
    private bool waterOn = false;
    private GameTimer gameTimer;
    private Disaester disaester;
    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        disaester = FindObjectOfType<Disaester>();
    }

    public void Interact()
    {
        if(!disaester.firstTimeDisaester)
        {
            waterOn = !waterOn;
            if (waterOn)
            {
                StartCoroutine(IncreaseWater());
            }
        }
    }

    private IEnumerator IncreaseWater()
    {
        while (waterOn && gameTimer != null && gameTimer.timerStarted)
        {
            float waterIncreasement = 1f;
            currentWater += waterIncreasement * Time.deltaTime;
            currentWater = Mathf.Clamp(currentWater, 0f, maxWater);

            if (currentWater >= maxWater)
            {
                waterOn = false;
                yield break; 
            }
            yield return null;
        }
    }
}