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
    public Canvas OrderCanvas;
    public Canvas Delivery;
    public GridScript gs;
    public GameObject crossMenu, iconMenu, crossShop, iconShop, crossNotepad, iconNotepad, crossEmail;

    private void Start()
    {
        ShopCanvas.gameObject.SetActive(false);
        Delivery.gameObject.SetActive(false);
        OrderCanvas.gameObject.SetActive(false);
    }

    //remove for final
    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnClickQuests()
    {
        if (OrderCanvas.gameObject.activeSelf)
        {
            crossNotepad.SetActive(false);
            iconNotepad.SetActive(true);
            OrderCanvas.gameObject.SetActive(false);
            gs.enabled = true;
        }
        else
        {
            crossNotepad.SetActive(true);
            iconNotepad.SetActive(false);
            OrderCanvas.gameObject.SetActive(true);
            gs.enabled = false;
        }
    }

    public void OnDeliveryAsk()
    {
        if (Delivery.gameObject.activeSelf)
        {
            Delivery.gameObject.SetActive(false);
            crossEmail.SetActive(false);
            if (GameManagerScript.instance.MoreAcceptedOrders == false)
            {
                GameManagerScript.instance.orderNotification.SetActive(false);
            }
            gs.enabled = true;
        }
        else
        {
            crossEmail.SetActive(true);
            Delivery.gameObject.SetActive(true);
            gs.enabled = false;
        }
    }

    public void OnClickShop()
    {
        if (ShopCanvas.gameObject.activeSelf)
        {
            ShopCanvas.gameObject.SetActive(false);
            crossShop.SetActive(false);
            iconShop.SetActive(true);
            GameManagerScript.instance.highlightedTile = new Vector3Int(-500, -500, -500);
            gs.enabled = true;
        }
        else
        {
            ShopCanvas.gameObject.SetActive(true);
            iconShop.SetActive(false);
            crossShop.SetActive(true);
            GameManagerScript.instance.highlightedTile = new Vector3Int(-500, -500, -500);
            gs.enabled = false;
        }
    }

    public void OnClickMenu()
    {
        if(MenuPanel.activeSelf)
        {
            MenuPanel.SetActive(false);
            crossMenu.SetActive(false);
            iconMenu.SetActive(true);
            gs.enabled = true;
        }
        else
        {
            MenuPanel.SetActive(true);
            crossMenu.SetActive(true);
            iconMenu.SetActive(false);
            gs.enabled = false;
        }
    }

    public void OnClickMainMenu()
    {
        //open main menu screen //not made yet
    }

    public void OnClickSaveSlots()
    {
        SceneManager.LoadScene("SaveSlots");
    }

    //quits game
    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void CloseConfirm()
    {
        GameManagerScript.instance.sleepConfirmCanvas.SetActive(false);
    }
}
