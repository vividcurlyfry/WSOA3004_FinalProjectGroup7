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

    private void Start()
    {
        ShopCanvas.gameObject.SetActive(false);
        Delivery.gameObject.SetActive(false);
        OrderCanvas.gameObject.SetActive(false);
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
        if (OrderCanvas.gameObject.activeSelf)
        {
            OrderCanvas.gameObject.SetActive(false);
            gs.enabled = true;
        }
        else
        {
            OrderCanvas.gameObject.SetActive(true);
            gs.enabled = false;
        }
    }

    public void OnDeliveryAsk()
    {
        if (Delivery.gameObject.activeSelf)
        {
            Delivery.gameObject.SetActive(false);
            if(GameManagerScript.instance.MoreAcceptedOrders == false)
            {
                GameManagerScript.instance.orderNotification.SetActive(false);
            }
            gs.enabled = true;
        }
        else
        {
            Delivery.gameObject.SetActive(true);
            gs.enabled = false;
        }
    }

    public void OnClickShop()
    {
        if (ShopCanvas.gameObject.activeSelf)
        {
            ShopCanvas.gameObject.SetActive(false);
            GameManagerScript.instance.highlightedTile = new Vector3Int(-500, -500, -500);
            gs.enabled = true;
        }
        else
        {
            ShopCanvas.gameObject.SetActive(true);
            GameManagerScript.instance.highlightedTile = new Vector3Int(-500, -500, -500);
            gs.enabled = false;
        }
    }

    public void OnClickMenu()
    {
        if(MenuPanel.activeSelf)
        {
            MenuPanel.SetActive(false);
            gs.enabled = true;
        }
        else
        {
            MenuPanel.SetActive(true);
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
