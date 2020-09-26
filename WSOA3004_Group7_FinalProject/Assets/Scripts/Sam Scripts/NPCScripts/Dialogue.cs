using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    private Queue<string> sentences;
    public GameObject heartImg;
    public Image RubySpeechBubble, DemiSpeechBubble;
    public Text RubyText, DemiText;
    public float secondsBetweenText = 3;

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

        string sentence1 = sentences.Dequeue();
        Debug.Log("Ruby:" + sentence1);
        RubySpeechBubble.enabled = true;
        RubyText.text = sentence1.ToString();
        RubyText.enabled = true;

        StartCoroutine(RubyResponseDelay());
    }

    void EndDialogue()
    {
        heartImg.SetActive(true);
        StartCoroutine(LoveDisplay());
        
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
    }
}
