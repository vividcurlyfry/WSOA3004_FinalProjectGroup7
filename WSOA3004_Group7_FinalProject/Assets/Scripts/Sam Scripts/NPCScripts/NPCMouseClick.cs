using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMouseClick : MonoBehaviour
{
    private int clicks = 0;

    private void OnMouseDown()
    {
        if(clicks == 0)
        {
            FindObjectOfType<DialogueTrigger>().TriggerDialogue();
            clicks++;
        }
        else
        {
            FindObjectOfType<Dialogue>().DisplayNextSentence();
        }
    }
}
