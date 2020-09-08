using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//control game UI //Samantha Thurgood 1827593
public class UIScript : MonoBehaviour
{
    public GameObject MenuPanel;

    public void OnClickQuests()
    {
        //activate quests panel //not made yet
    }

    public void OnClickShop()
    {
        //activate shop panel //not made yet
    }

    public void OnClickMenu()
    {
        if(MenuPanel.activeSelf)
        {
            MenuPanel.SetActive(false);
        }
        else
        {
            MenuPanel.SetActive(true);
        }
    }

    public void OnClickMainMenu()
    {
        //open main menu screen //not made yet
    }

    public void OnClickSaveSlots()
    {
        //open save slots screen //not made yet
    }

    //quits game
    public void OnClickQuit()
    {
        Application.Quit();
    }
}
