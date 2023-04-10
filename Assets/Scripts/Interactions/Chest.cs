using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{   
    [TextArea(minLines:0, maxLines:1)]
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    [TextArea(minLines: 0, maxLines: 1)]
    [SerializeField]
    private string keyname = "GeneralKey";
    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if (inventory.HasItem(keyname))
        {
              Debug.Log("Opening Chest");
        }
        Debug.Log("Opening Chest");
        return true;
    }
}
