using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float Seconds = 0;
    public Image DayImage;
    public float MinutesInDay = 20;
    public float SecondsInDay;
    public float SecondTimer;
    public float OneSecTimer = 0;

    private void Start()
    {
        SecondsInDay = MinutesInDay * 60;
        SecondTimer = 1 / SecondsInDay;
    }

    void Update()
    {
        Seconds += Time.deltaTime;
        OneSecTimer += Time.deltaTime;
        if(OneSecTimer >= 1)
        {
            DayImage.fillAmount = DayImage.fillAmount - SecondTimer;
            OneSecTimer = 0;
        }

        if(Seconds >= SecondsInDay)
        {
            GameManagerScript.instance.EndDay();
        }
    }
}
