﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueObject Day1, Day2, Day3, RainDay;
    private int today = 0;
    private bool isRaining = false;

    //on ruby click first time
    public void TriggerDialogue()
    {
        isRaining = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LivelinessEffects>().Raining;
        today = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().DaysPlayed;

        if (isRaining)
        {
            FindObjectOfType<Dialogue>().StartDialogue(RainDay);
        }
        else
        {
            if ((today == 0)|| (today == 3))
            {
                FindObjectOfType<Dialogue>().StartDialogue(Day1);
            }
            else if ((today == 1) || (today == 4))
            {
                FindObjectOfType<Dialogue>().StartDialogue(Day2);
            }
            else if ((today == 2)|| (today == 4))
            {
                FindObjectOfType<Dialogue>().StartDialogue(Day3);
            }
        }
    }
}
