using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState {START, PLAYERTURN, ENEMYTURN,WON,LOST }
public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    // Player 
    [SerializeField]
    private Transform player_postion;
    [SerializeField]
    private GameObject player;


    [SerializeField]
    private Transform[] enemy_postion;
    [SerializeField]
    private GameObject[] enemies;

    private void Awake()
    {
       
    }

    void Start() 
    {
        state = BattleState.START;

        player.transform.position = player_postion.position;

        // Check that the arrays are the same length
        if (enemies.Length != enemy_postion.Length)
        {
            Debug.LogError("Arrays must be the same length!");
            return;
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].transform.position = enemy_postion[i].position;
        }
    }
}
