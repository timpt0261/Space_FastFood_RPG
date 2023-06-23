using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField]
    private LayerMask enemymask;
    private CharacterController detector;


    private void Start()
    {
        detector = GetComponent<CharacterController>();

    }


    private void Update()
    {

    }

}
