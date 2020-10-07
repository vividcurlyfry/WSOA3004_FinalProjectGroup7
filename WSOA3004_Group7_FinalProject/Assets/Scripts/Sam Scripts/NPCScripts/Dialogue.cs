using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    private Queue<string> conversations;
    public GameObject heartImg, Ruby, Demi;
    public Image RubySpeechBubble, RubySpeechBubbleLow, RubySpeechBubbleLow2, RubySpeechBubbleRight, RubySpeechBubbleLeft, RubySpeechBubbleRightTop, RubySpeechBubbleLeftTop, DemiSpeechBubble;
    public Text RubyText, RubyTextLow, RubyTextLow2, RubyTextRight, RubyTextLeft, RubyTextRightTop, RubyTextLeftTop, DemiText;
    public float secondsBetweenText = 4;
    public bool talking = false, next = true;
    public string[] currConvo;
    private int today = 1;

    // Start is called before the first frame update
    void Start()
    {
        conversations = new Queue<string>();
        //today = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().Today;
    }

    public void StartDialogue(DialogueObject D)
    {
        conversations.Clear();

        foreach (string conversation in D.conversations)
        {
            conversations.Enqueue(conversation);
        }

        DisplayNextConversation();
    }


    //on ruby click after first time
    public void DisplayNextConversation()
    {
        string convo1 = "";

        if (conversations.Count == 0)
        {
            EndDialogue();
            return;
        }

        next = false;

        convo1 = conversations.Dequeue();
       
        GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCMovement>().talking = true;

        //Splitting convo into lines//
        currConvo = convo1.Split("\n"[0]);
        StartCoroutine(RunConvo());
    }

    IEnumerator RunConvo()
    {
        for (int i = 0; i < currConvo.Length; i++)
        {
            if (i % 2 == 0)
            {
                RubySpeechRun(currConvo[i].ToString());
                yield return StartCoroutine(RubyResponseDelay());
            }
            if (i % 2 == 1)
            {
                DemiSpeechRun(currConvo[i].ToString());
                yield return StartCoroutine(DemiResponseDelay());
            }
        }
        next = true;
        GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCMovement>().talking = false;
    }

    private void RubySpeechRun(string line)
    {
        Debug.Log("Ruby:" + line);
        if ((Ruby.transform.position.y - Demi.transform.position.y > 0.54f)&&(Demi.transform.position.x - Ruby.transform.position.x > 4.39f)) //below and right
        {
            RubySpeechBubbleLow.enabled = true;
            RubyTextLow.text = line.ToString();
            RubyTextLow.enabled = true;
        }
        if ((Ruby.transform.position.y - Demi.transform.position.y > 0.54f) && (Ruby.transform.position.x - Demi.transform.position.x > 4.48f)) //below and left
        {
            RubySpeechBubbleLow2.enabled = true;
            RubyTextLow2.text = line.ToString();
            RubyTextLow2.enabled = true;
        }
        else if ((Demi.transform.position.y - Ruby.transform.position.y > 1.63f)&& (Demi.transform.position.x - Ruby.transform.position.x > 4.39f)) //above and right
        {
            RubySpeechBubbleRightTop.enabled = true;
            RubyTextRightTop.text = line.ToString();
            RubyTextRightTop.enabled = true;
        }
        else if ((Demi.transform.position.y - Ruby.transform.position.y > 1.63f) && (Ruby.transform.position.x - Demi.transform.position.x > 4.48f)) //above and left
        {
            RubySpeechBubbleLeftTop.enabled = true;
            RubyTextLeftTop.text = line.ToString();
            RubyTextLeftTop.enabled = true;
        }
        else if (Demi.transform.position.x - Ruby.transform.position.x > 4.39f) //right
        {
            print((Demi.transform.position.x - Ruby.transform.position.x).ToString());
            RubySpeechBubbleRight.enabled = true;
            RubyTextRight.text = line.ToString();
            RubyTextRight.enabled = true;
        }
        else if (Ruby.transform.position.x - Demi.transform.position.x > 4.48f) //left
        {
            RubySpeechBubbleLeft.enabled = true;
            RubyTextLeft.text = line.ToString();
            RubyTextLeft.enabled = true;
        }
        else
        {
            RubySpeechBubble.enabled = true;
            RubyText.text = line.ToString();
            RubyText.enabled = true;
        }
    }

    IEnumerator RubyResponseDelay()
    {
        yield return new WaitForSeconds(secondsBetweenText);
        RubySpeechBubble.enabled = false;
        RubyText.enabled = false;
        RubySpeechBubbleLow.enabled = false;
        RubyTextLow.enabled = false;
        RubySpeechBubbleLow2.enabled = false;
        RubyTextLow2.enabled = false;
        RubySpeechBubbleRight.enabled = false;
        RubyTextRight.enabled = false;
        RubySpeechBubbleLeft.enabled = false;
        RubyTextLeft.enabled = false;
        RubySpeechBubbleRightTop.enabled = false;
        RubyTextRightTop.enabled = false;
        RubySpeechBubbleLeftTop.enabled = false;
        RubyTextLeftTop.enabled = false;
    }

    private void DemiSpeechRun(string line)
    {
        Debug.Log("Demi:" + line);
        DemiSpeechBubble.enabled = true;
        DemiText.text = line.ToString();
        DemiText.enabled = true;
    }

    IEnumerator DemiResponseDelay()
    {
        yield return new WaitForSeconds(secondsBetweenText);
        DemiSpeechBubble.enabled = false;
        DemiText.enabled = false;
    } 

    void EndDialogue()
    {
        heartImg.SetActive(true);
        StartCoroutine(LoveDisplay());
        GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCMovement>().talking = false;
    }

    IEnumerator LoveDisplay()
    {
        yield return new WaitForSeconds(1);
        heartImg.SetActive(false);
    }
}
