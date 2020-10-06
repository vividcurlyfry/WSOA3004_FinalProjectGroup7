using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    private Queue<string> sentences;
    public GameObject heartImg, Ruby, Demi;
    public Image RubySpeechBubble, RubySpeechBubbleLow, DemiSpeechBubble;
    public Text RubyText, RubyTextLow, DemiText;
    public float secondsBetweenText = 3;
    public bool talking = false, next = true;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(DialogueObject D)
    {
        sentences.Clear();

        foreach (string sentence in D.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }


    //on ruby click after first time
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        next = false;
        string sentence1 = sentences.Dequeue();
        Debug.Log("Ruby:" + sentence1);
            if(Ruby.transform.position.y > Demi.transform.position.y)
            {
                RubySpeechBubbleLow.enabled = true;
                RubyTextLow.text = sentence1.ToString();
                RubyTextLow.enabled = true;
            }
            else
            {
                RubySpeechBubble.enabled = true;
                RubyText.text = sentence1.ToString();
                RubyText.enabled = true;
            }

        StartCoroutine(RubyResponseDelay());
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

    IEnumerator RubyResponseDelay()
    {
        yield return new WaitForSeconds(secondsBetweenText);
        RubySpeechBubble.enabled = false;
        RubyText.enabled = false;
        RubySpeechBubbleLow.enabled = false;
        RubyTextLow.enabled = false;

        string sentence2 = sentences.Dequeue();
        Debug.Log("Demi:" + sentence2);
        DemiSpeechBubble.enabled = true;
        DemiText.text = sentence2.ToString();
        DemiText.enabled = true;
        StartCoroutine(DemiResponseDelay());
    }

    IEnumerator DemiResponseDelay()
    {
        yield return new WaitForSeconds(secondsBetweenText);
        DemiSpeechBubble.enabled = false;
        DemiText.enabled = false;
        next = true;
        GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCMovement>().talking = false;
    }
}
