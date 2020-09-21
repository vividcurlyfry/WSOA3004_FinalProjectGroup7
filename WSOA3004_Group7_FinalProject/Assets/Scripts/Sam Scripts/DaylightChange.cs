using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaylightChange : MonoBehaviour
{
    public TimerScript TS; //where is this script attached?

    private Color dawn, dusk;
    private float seconds, dawnSeconds, duskSeconds;
  
    void Start()
    {
        dawn = new Color(243, 91, 59, 0);
        dusk = new Color(44, 2, 118, 0);

        seconds = TS.SecondsInDay;
        dawnSeconds = Mathf.Floor(0.25f * seconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
