using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    private Queue<string> dialogueQueue;

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueQueue = new Queue<string>(dialogue.lines);
        // Start displaying dialogue UI and handle dialogue progression
    }

    public void EndDialogue()
    {
        // End the dialogue and hide dialogue UI
    }

    private void DisplayNextLine()
    {
        if (dialogueQueue.Count > 0)
        {
            string line = dialogueQueue.Dequeue();
            // Display the line in the dialogue UI
        }
        else
        {
            EndDialogue();
        }
    }
}