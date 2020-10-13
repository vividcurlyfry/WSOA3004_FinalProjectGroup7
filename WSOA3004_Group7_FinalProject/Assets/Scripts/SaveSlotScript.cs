using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSlotScript : MonoBehaviour
{
    public void SlotOne()
    {
        Slot.instance.ActiveSlot = 1;
        if (PlayerPrefs.GetString("DayOnePlayedSlotOne?") == "yes")
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            SceneManager.LoadScene("Intro 1");
        }
    }

    public void SlotTwo()
    {
        Slot.instance.ActiveSlot = 2;
        if (PlayerPrefs.GetString("DayOnePlayedSlotTwo?") == "yes")
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            SceneManager.LoadScene("Intro 1");
        }
    }

    public void SlotThree()
    {
        Slot.instance.ActiveSlot = 3;
        if (PlayerPrefs.GetString("DayOnePlayedSlotThree?") == "yes")
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            SceneManager.LoadScene("Intro 1");
        }
    }

    public void SlotFour()
    {
        Slot.instance.ActiveSlot = 4;
        if (PlayerPrefs.GetString("DayOnePlayedSlotFour?") == "yes")
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            SceneManager.LoadScene("Intro 1");
        }
    }
}
