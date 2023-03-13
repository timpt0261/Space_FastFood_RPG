using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;  // List of waypoints to follow
    private int currentWaypoint = 0;  // Current waypoint index
    private NavMeshAgent navAgent;  // Reference to NavMeshAgent component
    private bool isMovingForward = true;
    private CreatePath createPath;

    [SerializeField]
    private GameObject _player;


    // States for the state machine
    enum State
    {
        PATROL,
        CHASE,
        ATTACK
    }
    private State currentState = State.PATROL;  // Initial state

    void Start()
    {
        createPath = GetComponent<CreatePath>();
        navAgent = GetComponent<NavMeshAgent>();  // Get NavMeshAgent component reference

        waypoints = createPath.Construct(4, 20.0f, PathType.NGon,navAgent.transform);
        SetDestination();

        _player = GetComponent<GameObject>();
    }

    void Update()
    {
        switch (currentState)
        {
            case State.PATROL:
                // Move to next waypoint if enemy has reached current waypoint
                if (navAgent.remainingDistance <= navAgent.stoppingDistance)
                {
                    currentWaypoint++;
                    if (currentWaypoint >= waypoints.Length)
                    {
                        currentWaypoint = 0;
                    }
                    navAgent.SetDestination(waypoints[currentWaypoint].position);
                }
                


                // If the enemy has reached its current destination, set a new destination
                if (!navAgent.pathPending && na.remainingDistance < 0.5f)
                {
                    // If the enemy is moving forward, increment the current waypoint index, otherwise decrement it
                    if (isMovingForward)
                    {
                        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                    }
                    else
                    {
                        currentWaypoint = (currentWaypoint + waypoints.Length - 1) % waypoints.Length;
                    }

                    SetDestination();
                }

                // Transition to CHASE state if player is within a certain distance
                if (Vector3.Distance(transform.position, _player.transform.position) < 10f)
                {
                    currentState = State.CHASE;
                }
                break;

            case State.CHASE:
                navAgent.SetDestination(_player.transform.position);
                // Transition to ATTACK state if player is within a certain distance
                if (Vector3.Distance(transform.position, _player.transform.position) < 2f)
                {
                    currentState = State.ATTACK;
                }
                // Transition back to PATROL state if player moves far away
                if (Vector3.Distance(transform.position, _player.transform.position) > 20f)
                {
                    currentState = State.PATROL;
                }
                break;

            case State.ATTACK:
                // TODO: Implement attack behavior
                break;
        }
    }
    void SetDestination()
    {
        // Set the enemy's destination to the current waypoint
        navAgent.SetDestination(waypoints[currentWaypoint].position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position ,10.0f);
    }

}
