using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayChangeVisual : MonoBehaviour
{
    public bool dayOver = false, dayChange = false;
    public GameObject Lamp, Calendar;
    public Text date;
    public Sprite LightOn, LightOff;
    public AudioSource AS;
    public AudioClip nightAudio;
    public GameObject Ruby;

    private float t1 = 0, t2 = 0, speed = 1f, timeBetween = 0, timeStart = 0;
    private int today = 0;

    // Start is called before the first frame update
    void Start()
    {
        AS.volume = 0;
        dayChange = false;
        today = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().DaysPlayed + 1;
        dayOver = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().dayOver;
        GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCMovement>().enabled = true;
        dayChange = dayOver;

        t1 = 0;
        t2 = 2;
        timeStart = 0;
        timeBetween = 0;

        this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
        date.text = today.ToString();
        Calendar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        dayOver = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().dayOver;
        dayChange = dayOver;

        //start of day
        timeStart += Time.deltaTime;
        if(timeStart > 2f)
        {
            t1 = speed * Time.deltaTime;
            Calendar.SetActive(false);
        }

        //end of day
        if (dayChange)
        {
            GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCMovement>().enabled = false;
            t2 = 10f * speed * Time.deltaTime;
            AS.volume = Mathf.Lerp(0, 0.5f, 0.9f);
            Lamp.gameObject.GetComponent<SpriteRenderer>().sprite = LightOn;
            Lamp.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 202;

            this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, Mathf.Lerp(this.GetComponent<SpriteRenderer>().color.a, 1, t2));
            timeBetween += Time.deltaTime;
        }

        if (timeBetween > 4f)
        {
            Lamp.gameObject.GetComponent<SpriteRenderer>().sprite = LightOff;
            print("yee");
        }

        if (timeBetween > 6f) // test time length
        {
            Lamp.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 8;
            dayChange = false;
         
        }

        if (timeBetween > 7f) // test time length
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
