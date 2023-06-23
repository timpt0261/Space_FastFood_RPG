using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Character : MonoBehaviour
{
    [Header("Character")]

    [Tooltip("Move speed of the character in m/s")]
    [SerializeField]
    protected float MoveSpeed = 2.0f;

    [Tooltip("Sprint speed of the character in m/s")]
    [SerializeField]
    protected float SprintSpeed = 5.335f;

    [Tooltip("How fast the character turns to face movement direction")]
    [Range(0.0f, 0.3f)]
    [SerializeField]
    protected float RotationSmoothTime = 0.12f;

    [Tooltip("Acceleartion and decelaration")]
    [SerializeField]
    protected float SpeedChangeRate = 10.0f;

    [Header("Character Grounded")]
    [Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
    [SerializeField]
    protected bool Grounded = true;

    [Tooltip("Useful for rough ground")]
    [SerializeField]
    protected float GroundedOffset = -0.14f;

    [Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
    [SerializeField]
    protected float GroundedRadius = 0.28f;

    [Tooltip("What layers the character uses as ground")]
    [SerializeField]
    protected LayerMask GroundLayers;

    [Tooltip("Audio Clips for Character")]
    [SerializeField]
    protected AudioClip[] _charcterAudio;

    [SerializeField]
    [Range(0, 1)] protected float _charaterAudioVolume = 0.5f;

    [SerializeField]
    protected AudioSource _audioSource;



    [Header("Character Path")]
    [SerializeField]
    protected bool _isGoingBackandForth = false;

    [SerializeField]
    protected int _numPostions = 2;

    [SerializeField]
    protected float _totalDistance = 10.0f;


    
    // Behavior States
    protected CharacterState _currentState;


    // Charater 
    protected float _speed;
    protected GameObject _player;
    protected NavMeshAgent _navMeshAgent;
    protected CharacterStats _stats;
    protected Inventory _inventory;
    protected DialogueSystem _characterDilaougeSystem;


    protected Animator _animator;
    protected CharacterController _controller;
    protected Rigidbody _rigidbody;
    protected Collider _collider;

    private bool _hasAnimtor;

    protected virtual void Awake()
    {
        _player = GameObject.Find("Player");
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _controller = GetComponent<CharacterController>();



        _stats = new CharacterStats();
        _inventory = new Inventory(5, 10);
        _rigidbody = GetComponent<Rigidbody>();

        _characterDilaougeSystem = GetComponent<DialogueSystem>();

    }

    protected virtual void Start()
    {
        _hasAnimtor = TryGetComponent(out _animator);
        _navMeshAgent.speed = MoveSpeed;

        AssignAnimationIds();
    }

    protected virtual void Update()
    {
        // Handle behavior based on the current state
        HandleState();
    }

    protected virtual void LateUpdate() { 

    }

    protected virtual void HandleState()
    {
        switch (_currentState)
        {
            case CharacterState.Idle:
                // Handle idle behavior
                break;
            case CharacterState.Moving:
                // Handle movement behavior
                Move();
                break;
            case CharacterState.Interacting:
                // Handle interaction behavior
                Interact();
                break;
            case CharacterState.Dialogue:
                // Handle dialogue behavior
                Dialogue();
                break;
                // Add more behavior states as needed
        }
    }


    protected virtual void Move() 
    { 
    
    }

    protected virtual void Interact() {
    
    
    }


    protected virtual void Dialogue() {

    }


    protected virtual void AssignAnimationIds() {
    
    }

    protected void MoveToDestination(Vector3 destination)
    {
        _navMeshAgent.SetDestination(destination);
        _currentState = CharacterState.Moving;
    }

    protected void StopMoving()
    {
        _navMeshAgent.ResetPath();
        _currentState = CharacterState.Idle;
    }

    // Inventory related methods
    protected void AddItemToInventory(Item item)
    {
        _inventory.AddItem(item);
    }

    protected void UseItemInIventoy(Item item)
    {
        _inventory.UseItem(item);
    }

    protected void RemoveItemFromInventory(Item item)
    {
        _inventory.RemoveItem(item);
    }


    // Dialogue related methods
    protected void StartDialogue(Dialogue dialogue)
    {
        _characterDilaougeSystem.StartDialogue(dialogue);
        _currentState = CharacterState.Dialogue;
    }

    protected void EndDialogue()
    {
        _characterDilaougeSystem.EndDialogue();
        _currentState = CharacterState.Idle;
    }

}

// Enum to represent different character states
public enum CharacterState
{
    Idle,
    Moving,
    Interacting,
    Dialogue
}
