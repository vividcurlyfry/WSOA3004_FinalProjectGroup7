using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotScript : MonoBehaviour
{
    public bool clear1;
    public bool clear2;
    public bool clear3;
    public bool clear4;
    public GameObject youSure1;
    public GameObject youSure2;
    public GameObject youSure3;
    public GameObject youSure4;
    public Text Slot1Day;
    public Text Slot2Day;
    public Text Slot3Day;
    public Text Slot4Day;

    private void Start()
    {
        clear1 = false;
        clear2 = false;
        clear3 = false;
        clear4 = false;
        youSure1.SetActive(false);
        youSure2.SetActive(false);
        youSure3.SetActive(false);
        youSure4.SetActive(false);

        if (PlayerPrefs.GetString("DayOnePlayedSlotOne?") == "yes" && PlayerPrefs.GetInt("SlotOneDay") != 0)
        {
            Slot1Day.text = "DAY " + PlayerPrefs.GetInt("SlotOneDay").ToString();
        }
        else
        {
            Slot1Day.text = "EMPTY";
        }

        if (PlayerPrefs.GetString("DayOnePlayedSlotTwo?") == "yes" && PlayerPrefs.GetInt("SlotTwoDay") != 0)
        {
            Slot2Day.text = "DAY " + PlayerPrefs.GetInt("SlotTwoDay").ToString();
        }
        else
        {
            Slot2Day.text = "EMPTY";
        }

        if (PlayerPrefs.GetString("DayOnePlayedSlotThree?") == "yes" && PlayerPrefs.GetInt("SlotThreeDay") != 0)
        {
            Slot3Day.text = "DAY " + PlayerPrefs.GetInt("SlotThreeDay").ToString();
        }
        else
        {
            Slot3Day.text = "EMPTY";
        }

        if (PlayerPrefs.GetString("DayOnePlayedSlotFour?") == "yes" && PlayerPrefs.GetInt("SlotFourDay") != 0)
        {
            Slot4Day.text = "DAY " +  PlayerPrefs.GetInt("SlotFourDay").ToString();
        }
        else
        {
            Slot4Day.text = "EMPTY";
        }
    }

    public void clear1Sure()
    {
        youSure1.SetActive(true);
    }

    public void sure1Yes()
    {
        clear1 = true;
        youSure1.SetActive(false);
        PlayerPrefs.SetString("DayOnePlayedSlotOne?", "no");
        PlayerPrefs.SetInt("SlotOneDay?", 0);
        Slot1Day.text = "EMPTY";
    }

    public void sure1No()
    {
        clear1 = false;
        youSure1.SetActive(false);
    }

    public void clear2Sure()
    {
        youSure2.SetActive(true);
    }

    public void sure2Yes()
    {
        clear2 = true;
        youSure2.SetActive(false);
        PlayerPrefs.SetString("DayOnePlayedSlotTwo?", "no");
        PlayerPrefs.SetInt("SlotTwoDay?", 0);
        Slot2Day.text = "EMPTY";
    }

    public void sure2No()
    {
        clear1 = false;
        youSure2.SetActive(false);
    }

    public void clear3Sure()
    {
        youSure3.SetActive(true);
    }

    public void sure3Yes()
    {
        clear3 = true;
        youSure3.SetActive(false);        
        PlayerPrefs.SetString("DayOnePlayedSlotThree?", "no");
        PlayerPrefs.SetInt("SlotThreeDay?", 0);
        Slot3Day.text = "EMPTY";
    }

    public void sure3No()
    {
        clear3 = false;
        youSure3.SetActive(false);
    }

    public void clear4Sure()
    {
        youSure4.SetActive(true);
    }

    public void sure4Yes()
    {
        clear4 = true;
        youSure4.SetActive(false);
        PlayerPrefs.SetString("DayOnePlayedSlotFour?", "no");
        PlayerPrefs.SetInt("SlotFourDay?", 0);
        Slot4Day.text = "EMPTY";
    }

    public void sure4No()
    {
        clear4 = false;
        youSure4.SetActive(false);
    }

    public void SlotOne()
    {
        if (clear1 == false)
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
            Slot.instance.ActiveSlot = 1;
            PlayerPrefs.SetString("DayOnePlayedSlotOne?", "no");
            clear1 = false;
            SceneManager.LoadScene("Intro 1");
        }
    }

    public void SlotTwo()
    {
        if (clear2 == false)
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
            Slot.instance.ActiveSlot = 2;
            PlayerPrefs.SetString("DayOnePlayedSlotTwo?", "no");
            clear2 = false;
            SceneManager.LoadScene("Intro 1");
        }
    }

    public void SlotThree()
    {
        if (clear3 == false)
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
            Slot.instance.ActiveSlot = 3;
            PlayerPrefs.SetString("DayOnePlayedSlotThree?", "no");
            clear3 = false;
            SceneManager.LoadScene("Intro 1");
        }
    }

    public void SlotFour()
    {
        if (clear4 == false)
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
            Slot.instance.ActiveSlot = 4;
            PlayerPrefs.SetString("DayOnePlayedSlotFour?", "no");
            clear4 = false;
            SceneManager.LoadScene("Intro 1");
        }
    }
}
