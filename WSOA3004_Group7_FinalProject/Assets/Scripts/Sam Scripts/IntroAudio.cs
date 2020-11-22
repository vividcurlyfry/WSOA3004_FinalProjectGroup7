using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAudio : MonoBehaviour
{
   /* static IntroAudio instance;
    public AudioSource A;

    //allows music to play smoothly across the game
    void Awake()
    {
        if ((SceneManager.GetActiveScene().buildIndex > 4))
        {
            A.Stop();
        }

        if ((instance == null) && ((SceneManager.GetActiveScene().buildIndex < 5)))
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }*/
}
