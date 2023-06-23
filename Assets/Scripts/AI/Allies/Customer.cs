using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : Ally_Character
{
    private CustomerState _customerState;

    protected override void HandleState()
    {
        switch (_customerState)
        {
            case CustomerState.INLINE:
                break;
            case CustomerState.ORDER:
                break;
            case CustomerState.WAIT:
                break;
            case CustomerState.EAT:
                break;
            case CustomerState.LEAVE:
                break;
            default:
                break;
        }

    }

    protected override void Awake()
    {

    }

    protected override void Start()
    {

    }

    protected override void Update()
    {
        base.Update();
        
    }
}


public enum CustomerState { INLINE, ORDER, WAIT, EAT,LEAVE }