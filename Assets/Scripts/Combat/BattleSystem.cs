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

    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnCombatStart;

    }

    private void OnCombatStart(GameState state)
    {
        
        
    }

 
}
