using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    bool e = true;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    //DEBUG, DELETE AFTERWARDS
    void Update()
    {
        if (e)
        {
            TriggerDialogue();
            e = false;
        }
        
    }
}
