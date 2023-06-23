using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : Ally_Character
{
    protected CommonerState _backgroundState;

    
    protected override void HandleState()
    {

    }

    protected override void Awake()
    {
        base.Awake();
    }

}


public enum CommonerState { IDLE, WANDER, INTERACT, TALK };