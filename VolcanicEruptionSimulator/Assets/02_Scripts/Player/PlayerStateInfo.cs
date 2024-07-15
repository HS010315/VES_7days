using System;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Walking,
    Running,
    Interacting,
    Sleeping,
    Fainting,
    Dying
}

public enum PlayInfo
{
    Hp,
    Hunger,
    Fatigue,
    Contamination,
    Panic
}

public class PlayerStateInfo : MonoBehaviour
{
    private int hp;
    private int hunger;
    private int fatigue;
    private int contamination;
    private int panic;

    public PlayerState CurrentState { get; private set; }

    public int Hp
    {
        get { return hp; }
        set
        {
            hp = Mathf.Clamp(value, 0, 100);
            if (hp == 0)
            {
                CurrentState = PlayerState.Dying;
                HandleDyingState();
            }
        }
    }

    public int Hunger
    {
        get { return hunger; }
        set
        {
            hunger = Mathf.Clamp(value, 0, 100);
            CheckPlayInfoValues();
        }
    }

    public int Fatigue
    {
        get { return fatigue; }
        set
        {
            fatigue = Mathf.Clamp(value, 0, 100);
            CheckPlayInfoValues();
        }
    }

    public int Contamination
    {
        get { return contamination; }
        set
        {
            contamination = Mathf.Clamp(value, 0, 100);
            CheckPlayInfoValues();
        }
    }

    public int Panic
    {
        get { return panic; }
        set
        {
            panic = Mathf.Clamp(value, 0, 100);
            CheckPlayInfoValues();
        }
    }

    void Start()
    {
        Hp = 100;
        Hunger = 0;
        Fatigue = 0;
        Contamination = 0;
        Panic = 0;
        CurrentState = PlayerState.Idle;
    }

    void Update()
    {
        // 예제 업데이트 로직
        // 필요에 따라 플레이어 상태를 업데이트할 수 있음
    }

    private void HandleDyingState()
    {
        Debug.Log("Player is Dying");
    }

    private void CheckPlayInfoValues()
    {
        if (Hunger >= 70 || Fatigue >= 70 || Contamination >= 70 || Panic >= 70)
        {
            Debug.Log("One of the PlayInfo values is 70 or higher");
        }

        if (Hunger == 100 || Fatigue == 100 || Contamination == 100 || Panic == 100)
        {
            Debug.Log("One of the PlayInfo values is 100");
        }
    }
}