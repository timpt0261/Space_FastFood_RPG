using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerToWorldManager : MonoBehaviour
{
    // This script should change the Player respond to the WorldManger
    private PlayerInput input;
    private void Awake()
    {
        GameManager.OnGameStateChanged += IsExploring;

        input = GetComponent<PlayerInput>();
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= IsExploring;
    }


    // The Following Script Disable the player's input when not exploring or in th lobby
    private void IsExploring(GameState state)
    {
        bool canMove = state == GameState.EXPLORATION || state == GameState.LOBBY;

        if (canMove)
        {
            input.actions.Enable();
        }
        else
        {
            input.actions.Disable();
        }

    }
    
}
