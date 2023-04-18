using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//public enum BattleState {START, PLAYERTURN, ENEMYTURN,WON,LOST }
public class BattleSystem : MonoBehaviour
{
    // Player 
    [SerializeField]
    private Transform player_postion;
    [SerializeField]
    private GameObject player;


    [SerializeField]
    private Transform[] enemy_postion;
    [SerializeField]
    private GameObject[] enemies;

    private Queue turnorder;

    private void Awake()
    {
        GameManager.OnGameStateChanged += OnCombatStart;
        GameManager.OnGameStateChanged += OnPlayerTurn;
        GameManager.OnGameStateChanged += OnEnemyTurn;
        GameManager.OnGameStateChanged += OnCombatEnd;

    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnCombatStart;
        GameManager.OnGameStateChanged -= OnPlayerTurn;
        GameManager.OnGameStateChanged -= OnEnemyTurn;
        GameManager.OnGameStateChanged -= OnCombatEnd;
    }

    private void OnCombatStart(GameState state)
    {
        if (state == GameState.ENTER_COMBAT) 
        {
            // Determine who attacked first

            // Set up scene to have player and enmies placed 

            // Disable Input to player 
            
            
            // Switch to eithier player or enemy turn based query

            
        }
    }

    private void OnPlayerTurn(GameState state) 
    {
        if (state == GameState.PLAYER_TURN) 
        {
            // 
            
        }
    }

    private void OnEnemyTurn(GameState state) 
    {
        if (state == GameState.ENEMY_TURN) 
        {
            
        }
    }

    private void OnCombatEnd(GameState state) 
    {
        if (state == GameState.LEAVING_COMBAT) 
        {
            
        }
    }
}
