using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    walking,
    running,
    interacting,
    laying,
    fainting,
    dying
}

public enum PlayInfo
{
    GameTime,
    Hp,
    Hunger,
    Fatigue,
    Contamination,
    Panic
}
public class PlayerStateInfo
{
    public PlayInfo _playInfo;
    public PlayerState _playerState;
}