using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCMouseClick : MonoBehaviour
{
    private int clicks = 0;
    private float startTime, endTime;
    private bool next = true, clicked = false;

    public GameObject ShopUI;
    public GameObject Bed, heart;
    public Image fillHeart;

    private void Update()
    {
        if (((this.transform.position.x > 14.9f) && (this.transform.position.x < 17.1f)) && ((this.transform.position.x > 14.9f)&&(this.transform.position.y < 20.1f))) //check this??
        {
            Bed.SetActive(false);
        }
        else
        {
            Bed.SetActive(true);
        }

        
        if(clicked)
        {
            fillHeart.fillAmount += 0.025f;
        }


    }
    
    private void OnMouseDown()
    {
        startTime = Time.time;
        if (!GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCMovement>().talking)
        {
            clicked = true;
            heart.SetActive(true);
        }
        else
        {
            clicked = false;
        }
    }

    private void OnMouseUp()
    {
        endTime = Time.time;
        next = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<Dialogue>().next;
        clicked = false;
        heart.SetActive(false);
        fillHeart.fillAmount = 0;

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
