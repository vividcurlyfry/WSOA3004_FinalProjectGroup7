using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMouseClick : MonoBehaviour
{
    private int clicks = 0;
    private float startTime, endTime;
    private bool next = true;

    private void OnMouseDown()
    {
        startTime = Time.time;
    }

    private void OnMouseUp()
    {
        endTime = Time.time;
        next = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<Dialogue>().next;

        if (endTime - startTime > 0.3f)
        {
            if (clicks == 0)
            {
                FindObjectOfType<DialogueTrigger>().TriggerDialogue();
                clicks++;
            }
            else
            {
                if (next == true)
                {
                    FindObjectOfType<Dialogue>().DisplayNextConversation();
                }
            }
        }
    }
}
