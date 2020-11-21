using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotScript : MonoBehaviour
{
    public bool clear;
    public Button butt1;
    public Button butt2;
    public Button butt3;
    public Button butt4;

    private void Start()
    {
        clear = false;
    }

    public void ClearButt() //hehe, butt
    {
        if (clear == false)
        {
            clear = true;
            butt1.GetComponent<Image>().color = Color.HSVToRGB(0, 45, 100);
            butt2.GetComponent<Image>().color = Color.HSVToRGB(0, 45, 100);
            butt3.GetComponent<Image>().color = Color.HSVToRGB(0, 45, 100);
            butt4.GetComponent<Image>().color = Color.HSVToRGB(0, 45, 100);
        }
        else
        {
            clear = false;
            butt1.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            butt2.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            butt3.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            butt4.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
        }
    }

    public void SlotOne()
    {
        if (clear == false)
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
        else
        {
            PlayerPrefs.SetString("DayOnePlayedSlotOne?", "no");
            clear = false;
            butt1.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            butt2.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            butt3.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            butt4.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
        }
    }

    public void SlotTwo()
    {
        if (clear == false)
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
        else
        {
            PlayerPrefs.SetString("DayOnePlayedSlotTwo?", "no");
            clear = false;
            butt1.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            butt2.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            butt3.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            butt4.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
        }
    }

    public void SlotThree()
    {
        if (clear == false)
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
        else
        {
            PlayerPrefs.SetString("DayOnePlayedSlotThree?", "no");
            clear = false;
            butt1.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            butt2.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            butt3.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            butt4.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
        }
    }

    public void SlotFour()
    {
        if (clear == false)
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
        else
        {
            PlayerPrefs.SetString("DayOnePlayedSlotFour?", "no");
            clear = false;
            butt1.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            butt2.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            butt3.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            butt4.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
        }
    }
}
