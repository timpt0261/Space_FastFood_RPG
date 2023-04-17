using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    //public UnityAction<GameState> UnityAction;


    public void Awake()
    {
        Instance = this;
    }

    public void UpdateGameState(GameState newGameState)
    {
        State = newGameState;

        switch (newGameState)
        {
            case GameState.PAUSE:
                break;
            case GameState.EXPLORATION:
                break;
            case GameState.DIALOUGE:
                break;
            case GameState.INVENTORY:
                break;
            case GameState.INTERACTION:
                break;
            case GameState.COMBAT:
                break;
            case GameState.RUSH_HOUR:
                break;
            case GameState.RESTURANT_PROGRESSION:
                break;
        }

    }

    public enum GameState 
{
    PAUSE,
    EXPLORATION,
    DIALOUGE,
    INVENTORY,
    INTERACTION,
    COMBAT,
    RUSH_HOUR,
    RESTURANT_PROGRESSION
}
}