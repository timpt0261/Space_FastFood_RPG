using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Identify all the interactive objects in the game world: The manager would need to identify all the interactive objects in the game world and store references to them in an array or list.

Detect player interactions: The manager would need to detect when the player interacts with an interactive object. This could be done using raycasting, collision detection, or other methods depending on the type of interaction.

Determine the type of interaction: Once an interaction is detected, the manager would need to determine the type of interaction. For example, the player might be picking up an item, pressing a button, or entering a door.

Perform the appropriate action: Based on the type of interaction, the manager would need to perform the appropriate action. This might involve disabling the interactive object, playing an animation, updating a UI element, or initiating a dialogue sequence.

Manage interaction states: The manager would need to keep track of the state of each interactive object, such as whether it has already been interacted with or whether it is currently active or inactive. This would help prevent unintended interactions and ensure that the game world remains consistent and coherent.

Handle errors and edge cases: The manager would need to handle errors and edge cases, such as interactions that are not allowed in certain contexts or interactions that are interrupted by other events in the game world.
 
*/
public class InteractableManager : MonoBehaviour
{
    private GameObject[] interactables;

    private void Start()
    {

        if (interactables == null)
        {
            interactables = GameObject.FindGameObjectsWithTag("Interactable_Item");
        }       
    }
}



