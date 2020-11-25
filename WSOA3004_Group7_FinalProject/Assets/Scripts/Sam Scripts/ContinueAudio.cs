using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueAudio : MonoBehaviour
{
     static ContinueAudio instance;
    public AudioSource AS;

    //allows music to play smoothly across the game
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "DayOver")
        {
            AS.volume = 0;
        }
        else
        {
            AS.volume = 0.5f;
        }
    }
}
