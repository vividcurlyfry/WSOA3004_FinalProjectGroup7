using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueObject Day1, Day2, Day3, RainDay;
    private int today = 1;
    private bool isRaining = false;

    //on ruby click first time
    public void TriggerDialogue()
    {
        isRaining = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LivelinessEffects>().Raining;
        //today = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().Today;

        if(isRaining)
        {
            FindObjectOfType<Dialogue>().StartDialogue(RainDay);
        }
        else
        {
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
}
