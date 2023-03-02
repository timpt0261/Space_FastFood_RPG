using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    //private InputActions actions;
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private Interaction_Ui _interaction_Ui;


    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numfound;

    private IInteractable _interactable;

    
    private void Update()
    {
        _numfound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius,_colliders, _interactableMask);

        if (_numfound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();

            if (_interactable != null)
            {
                if (!_interaction_Ui.IsDisplayed) _interaction_Ui.SetUp(_interactable.InteractionPrompt);

                if (Keyboard.current.eKey.wasPressedThisFrame) _interactable.Interact(this);
            }

        }
        else 
        {
            if (_interactable != null) _interactable=null;
            if (_interaction_Ui.IsDisplayed) _interaction_Ui.Close();
        }


    }
    /*
    void Awake()
    {
        actions.actions["Interact"].onPressed += OnInteract;
    }

    void OnInteract()
    {
        Debug.Log("Interacting");
    }
    */

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
