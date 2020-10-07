using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaylightChange : MonoBehaviour
{
   
    public float minutes;
    private Color dawn, dusk, dawnEnd, duskEnd;
    public float dawnSeconds, duskSeconds, count, t = 0;
  
    void Start()
    {
        dawn = new Color32(243, 91, 59, 52);
        dawnEnd = new Color32(243, 91, 59, 0);
        dusk = new Color32(44, 2, 118, 0);
        duskEnd = new Color32(44, 2, 118, 130);

        minutes = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TimerScript>().MinutesInDay;
        minutes = minutes * 60;
        dawnSeconds = Mathf.Floor(0.25f * minutes);
        duskSeconds = 3 * dawnSeconds;

        this.GetComponent<SpriteRenderer>().color = dawn;

        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if (count < dawnSeconds)
        {
            this.GetComponent<SpriteRenderer>().color = Color.Lerp(dawn, dawnEnd, t);
            if (t < 1)
            {
                t += Time.deltaTime / dawnSeconds;
            }
        }

        if ((count > dawnSeconds)&&(count < duskSeconds))
        {
            this.GetComponent<SpriteRenderer>().color = new Color(dawn.r, dawn.g, dawn.b, 0);
            t = 0;
        }

        if(count > duskSeconds)
        {
            this.GetComponent<SpriteRenderer>().color = Color.Lerp(dusk, duskEnd, t);
            if (t < 1)
            {
                t += Time.deltaTime / dawnSeconds;
            }
        }
    }
}
