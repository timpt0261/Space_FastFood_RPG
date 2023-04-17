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

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        UpdateGameState(GameState.GAME_START);
    }

    public void UpdateGameState(GameState newGameState)
    {
        State = newGameState;


        switch (newGameState)
        {
            case GameState.DEFUALT:
                break;
            case GameState.DIALOUGE:
                HandelDialouge();
                break;
            case GameState.EXPLORATION:
                HandelExploration();
                break;
            case GameState.ENTER_COMBAT:
                HandelCombat();
                break;
            case GameState.LEAVING_COMBAT:
                break;
            case GameState.INVENTORY:
                break;
            case GameState.INTERACTION:
                break;
            case GameState.ENTER_SERVING:
                break;
            case GameState.PLAYER_TURN:
                break;
            case GameState.ENEMY_TURN:
                break;
            case GameState.LEAVING_SERVING:
                break;
            case GameState.GAME_OVER:
                break;
            case GameState.GAME_START:
                break;
            case GameState.LOBBY:
                break;
            case GameState.MENU:
                break;
            case GameState.OPTIONS:
                break;
           
        }

        OnGameStateChanged?.Invoke(newGameState);
    }

    private void HandelCombat()
    {
        throw new NotImplementedException();
    }

    private void HandelExploration()
    {
        // 
    }

    private void HandelDialouge()
    {
        // Pause all enemies
        // Pull up Menu 
        // Read script
    }
}

public enum GameState
{
    DEFUALT,
    DIALOUGE, // When ever player is speaking with NPC
    EXPLORATION, // When ever the player is outside the resturant
    ENTER_COMBAT, // When the Player is now fighting an Enemy (Movment should be turned off)
    PLAYER_TURN,
    ENEMY_TURN,
    LEAVING_COMBAT, // Update level progression of the Player and Invetory
    INVENTORY, // When the Player Pulls up thier inventort
    INTERACTION, // When Player sees Door, Chest, or Plant
    ENTER_SERVING, // Player has now playing mini-game
    LEAVING_SERVING, // Update Money Gained, Level Progression, Possible Resturna Upgrades
    GAME_OVER, // Should Play when the player has been killed
    GAME_START, // Should resume Gameplay from last save point

    LOBBY,        //Player is in the lobby
    MENU,         //Player is viewing in-game menu
    OPTIONS       //player is adjusting game options*/
}