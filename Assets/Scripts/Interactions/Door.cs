using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    // To be able to distinguish keys
    [SerializeField]
    private string keyname = "GeneralKey";
    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if (inventory.HasItem(keyname)) 
        {
            Debug.Log("Opening Door");

        }
        
        return true;
    }
}
