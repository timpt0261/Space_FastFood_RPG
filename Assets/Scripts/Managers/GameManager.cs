using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;

    private float gameStartDelay = 0.5f; // Delay in seconds before switching to Game.EXPLORATION
    private float gameStartTimer;

    public void Awake()
    {
        Instance = this;
        gameStartTimer = gameStartDelay;
    }

    public void Start()
    {
        UpdateGameState(GameState.GAME_START);
    }

    public void Update()
    {
        switch (State)
        {
            case GameState.GAME_START:
                // Check if the timer has reached the delay
                if (gameStartTimer <= 0f)
                {
                    // Switch to Game.EXPLORATION
                    UpdateGameState(GameState.EXPLORATION);

                    // Reset the timer
                    gameStartTimer = gameStartDelay;
                }
                else
                {
                    // Update the timer
                    gameStartTimer -= Time.fixedDeltaTime;
                }
                break;
            default:
                UpdateGameState(State);
                break;
        }
    }

    public void UpdateGameState(GameState newGameState)
    {
        State = newGameState;

        switch (newGameState)
        {
            case GameState.DEFUALT:
                break;
            case GameState.EXPLORATION:
                break;
            case GameState.ENTER_COMBAT:
                break;
            case GameState.PLAYER_TURN:
                break;
            case GameState.ENEMY_TURN:
                break;
            case GameState.SERVING:
                break;
            case GameState.GAME_OVER:
                break;
            case GameState.GAME_START:
                break;
            case GameState.LOBBY:
                break;
            case GameState.MENU:
                // Refense to script
                break;
            case GameState.OPTIONS:
                break;
        }
        OnGameStateChanged?.Invoke(newGameState);
    }
}

public enum GameState
{
    DEFUALT,
    EXPLORATION, // When ever the player is outside the resturant
    ENTER_COMBAT, // When the Player is now fighting an Enemy (Movment should be turned off)
    PLAYER_TURN,
    ENEMY_TURN,
    SERVING, // Player has now playing mini-game
    GAME_OVER, // Should Play when the player has been killed
    GAME_START, // Should resume Gameplay from last save point
    LOBBY,        //Player is in the lobby
    MENU,         //Player is viewing in-game menu
    OPTIONS       //player is adjusting game options
}
