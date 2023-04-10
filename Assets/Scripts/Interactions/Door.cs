using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [TextArea(minLines: 0, maxLines: 1)]
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    // To be able to distinguish keys
    [TextArea(minLines: 0, maxLines: 1)]
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
