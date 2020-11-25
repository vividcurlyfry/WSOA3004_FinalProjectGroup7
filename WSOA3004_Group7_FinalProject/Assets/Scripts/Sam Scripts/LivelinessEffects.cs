using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivelinessEffects : MonoBehaviour
{
    public bool Raining = false;
    public GameObject RainEffect, BeesEffect, RainNoise;

    private int randomNum = 0;

    private void Awake()
    {
        LivelinessSet();
    }

    //maybe playtest chance of rain
    public void LivelinessSet()
    {
        randomNum = Random.Range(0,3);

        switch (randomNum)
        {
            case 0:
                RainEffect.SetActive(true);
                BeesEffect.SetActive(false);
                Raining = true;
                RainNoise.SetActive(true);
                break;
            default:
                RainEffect.SetActive(false);
                BeesEffect.SetActive(true);
                Raining = false;
                RainNoise.SetActive(false);
                break;
        }
    }
}
