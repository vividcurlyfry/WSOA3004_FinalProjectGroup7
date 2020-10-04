using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//control game UI //Samantha Thurgood 1827593
public class UIScript : MonoBehaviour
{
    public GameObject MenuPanel;
    public Canvas ShopCanvas;

    private void Start()
    {
        ShopCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnClickQuests()
    {
        //activate quests panel //not made yet
    }

    public void OnClickShop()
    {
        if (ShopCanvas.gameObject.activeSelf)
        {
            ShopCanvas.gameObject.SetActive(false);
        }
        else
        {
            ShopCanvas.gameObject.SetActive(true);
        }
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
