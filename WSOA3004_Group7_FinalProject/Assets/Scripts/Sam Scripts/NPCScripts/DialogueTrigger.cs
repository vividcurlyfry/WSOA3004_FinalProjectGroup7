using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueObject Day1, Day2, Day3;
    private int today = 3;

    //on ruby click first time
    public void TriggerDialogue()
    {
        //add rainy day
        //today = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().Today; //Amy needs to add this connection
        if (today == 1)
        {
            FindObjectOfType<Dialogue>().StartDialogue(Day1);
        }
        else if (today == 2)
        {
            FindObjectOfType<Dialogue>().StartDialogue(Day2);
        }
        else if (today == 3)
        {
            FindObjectOfType<Dialogue>().StartDialogue(Day3);
        }

    }
}
