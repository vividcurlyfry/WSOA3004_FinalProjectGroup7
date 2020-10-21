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

    private float t = 0, speed = 1f, timeBetween = 0;
    private int today = 0;

    // Start is called before the first frame update
    void Start()
    {
        AS.volume = 0;
        dayChange = false;
        today = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().DaysPlayed + 2;
        dayOver = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().dayOver;
        dayChange = dayOver;
    }

    // Update is called once per frame
    void Update()
    {
        t = speed * Time.deltaTime;
        dayOver = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().dayOver;
        dayChange = dayOver;

        if (dayChange)
        {
            AS.volume = Mathf.Lerp(0, 0.5f, 0.9f);
            Lamp.gameObject.GetComponent<SpriteRenderer>().sprite = LightOn;
            Lamp.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 202;

            this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, Mathf.Lerp(this.GetComponent<SpriteRenderer>().color.a, 1, t));
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
        }

        if (timeBetween > 7f) // test time length
        {
            date.text = today.ToString();
            Calendar.SetActive(true);
        }

        if (timeBetween > 9f) // test time length
        {
            Calendar.SetActive(false);
        }

        if (timeBetween > 10f) // test time length
        {
            dayChange = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
