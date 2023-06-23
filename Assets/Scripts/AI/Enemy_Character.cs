using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Character : Character {

    [Header("Enemy")]

    [Tooltip("Determines wheather the enmey see you as predator or prey")]
    [SerializeField]
    [Range(1, 5)] protected int hierachy = 1;
    protected EnemyStates _enemyStates;

    [Header("Enemy Detection")]

    [SerializeField]
    private float _detectionDistance = 100f;

    [SerializeField]
    private LayerMask targetLayer;
    protected override void Awake()
    {

        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }


    protected override void Update()
    {

        isLineOfSight();

    }

    protected bool isLineOfSight()
    {
        RaycastHit hit;
        Vector3 directionOfPlayer = _player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, directionOfPlayer, out hit, _detectionDistance, targetLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player Detected: " + hit.collider.gameObject.name);
                Debug.DrawLine(transform.position, hit.point, Color.red);
                return true;
            }
        }

        Debug.DrawRay(transform.position, directionOfPlayer * _detectionDistance, Color.green);
        return false;
    }


}


public enum EnemyStates { IDLE, WAIT, MOVING, CHASE, FLEE, ATTACK, DEFEND, DEAD };