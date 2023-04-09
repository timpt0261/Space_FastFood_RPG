using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;  // List of waypoints to follow
    private int currentWaypoint = 0;  // Current waypoint index
    private NavMeshAgent navAgent;  // Reference to NavMeshAgent component
    private bool isMovingForward = true;
    private CreatePath createPath;
    private CustomPath customPath;
    private enum Type { GROUND, LAND, AERIAL, MARINE }

    [SerializeField]
    private GameObject _player;

    [Header("AI Path")]

    [Tooltip("Number of postion the AI should have")]
    [SerializeField]
    private int num_postions = 4;

    [Tooltip("Total Distance the AI should walk ")]
    [SerializeField]
    private float total_dist = 20.0f;

    [Tooltip("Shape of Pathway")]
    [SerializeField]
    private PathType pathType = PathType.NGon;

    [SerializeField]
    bool custom;

    [Tooltip("Should AI walk back and forths")]
    [SerializeField]
    private bool oneWay = true;

    [Header("Enemy Detection")]

    [SerializeField]
    private float radius = 10.0f;

    [SerializeField]
    private float angle = 10.0f;

    [SerializeField]
    private Type enemyType = Type.LAND;


    private bool player_Detected = false;    

    // States for the state machine
    enum State {IDLE, PATROL, CHASE, ATTACK}
    private State currentState = State.PATROL;  // Initial state

    void Start()
    {
        createPath = GetComponent<CreatePath>();
        navAgent = GetComponent<NavMeshAgent>();  // Get NavMeshAgent component reference

        waypoints = createPath.Construct(num_postions, total_dist, pathType,navAgent.transform);
        SetDestination();

        _player = GetComponent<GameObject>();
    }

    void Update()
    {
        switch (currentState)
        {
            case State.IDLE:
                //Wait for span of 5 secs to then move then postion to next way point
                // In the During it's idle period that the enemy is close switch to chase

                float startTime = Time.deltaTime;
                break;
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
                if (!navAgent.pathPending && navAgent.remainingDistance < 0.5f)
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


    private void SetDestination()
    {
        // Set the enemy's destination to the current waypoint
        navAgent.SetDestination(waypoints[currentWaypoint].position);
    }


    // Ennemy AI is in idle state
    private void Idle() 
    {
        // Stays in Place
        
    }

     private void Patrol() 
    {
        // Walks in specific path
        if (oneWay) 
        {

            
        }
    
    }

    private void Flee() { 
    
    }

     private void Chase() 
    {
        // Chases playe if in feild in view
        
    }
    private void Attack() 
    { 
        // Attacks player
    
    }

}
