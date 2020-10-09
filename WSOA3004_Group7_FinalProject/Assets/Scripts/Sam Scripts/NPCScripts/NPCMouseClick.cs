using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMouseClick : MonoBehaviour
{
    private int clicks = 0;
    private float startTime, endTime;
    private bool next = true;

    public GameObject ShopUI;
    public GameObject Bed;

    private void Update()
    {
        if (this.transform.position == new Vector3(17.69f, 15, -1))
        {
            Bed.SetActive(false);
        }
        else
        {
            Bed.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        startTime = Time.time;
    }

    private void OnMouseUp()
    {
        endTime = Time.time;
        next = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<Dialogue>().next;

        //checking if in the house or shop UI is up
        if ((this.transform.position == new Vector3(17.69f, 16f, -1)) || (ShopUI.gameObject.activeSelf))
        {
            print("no click");
        }
        else
        {
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
}
