using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] Transform startPostion;
    [SerializeField] Transform endPostion;

    //[SerializeField] Transform[] pathway;
    private NavMeshAgent nav_agent;

    private void Start()
    {
        nav_agent = GetComponent<NavMeshAgent>();
        nav_agent.SetDestination(endPostion.position);
    }

    public void Update()
    {
        if (nav_agent.remainingDistance < 0.1f)
        {
            if (nav_agent.destination == endPostion.position)
            {
                nav_agent.SetDestination(startPostion.position);
            }
            else
            {
                nav_agent.SetDestination(endPostion.position);
            }
        }
    }

}
