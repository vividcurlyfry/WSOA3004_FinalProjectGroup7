using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundBeforeCloseButton : MonoBehaviour
{
    public AudioSource AS;

    public void PlaySoundButton()
    {
        if(this != null)
        {
            AS.Play(0);
        }
    }
}
