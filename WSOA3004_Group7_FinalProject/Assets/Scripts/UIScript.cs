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
    public int shopSorting, orderSorting, deliverySorting, menuSorting;
    public DayChangeVisual dcv;

    public void Awake()
    {
        dcv.enabled = true;
    }

    private void Start()
    {
        ShopCanvas.gameObject.SetActive(false);
        Delivery.gameObject.SetActive(false);
        OrderCanvas.gameObject.SetActive(false);
        orderSorting = OrderCanvas.sortingOrder;
        deliverySorting = Delivery.sortingOrder;
        shopSorting = ShopCanvas.sortingOrder;
    }

    public void OnClickQuests()
    {
        if (OrderCanvas.gameObject.activeSelf)
        {
            crossNotepad.SetActive(false);
            iconNotepad.SetActive(true);
            OrderCanvas.gameObject.SetActive(false);
            gs.enabled = true;
            OrderCanvas.sortingOrder = orderSorting;
        }
        else
        {
            crossNotepad.SetActive(true);
            iconNotepad.SetActive(false);
            OrderCanvas.gameObject.SetActive(true);
            gs.enabled = false;
            OrderCanvas.sortingOrder = orderSorting + 1;
            ShopCanvas.sortingOrder = shopSorting;
            Delivery.sortingOrder = deliverySorting;
        }
    }

    public void OnDeliveryAsk()
    {
        if (Delivery.gameObject.activeSelf)
        {
            Delivery.gameObject.SetActive(false);
            crossEmail.SetActive(false);
            if ((GameManagerScript.instance.displayedOrders[0].Accepted == true && GameManagerScript.instance.displayedOrders[1].Accepted == true) || (GameManagerScript.instance.displayedOrders[0].Accepted == true && GameManagerScript.instance.displayedOrders[1].Rejected == true) || (GameManagerScript.instance.displayedOrders[0].Rejected == true && GameManagerScript.instance.displayedOrders[1].Accepted == true) || (GameManagerScript.instance.displayedOrders[0].Rejected == true && GameManagerScript.instance.displayedOrders[1].Rejected == true))
            {
                GameManagerScript.instance.orderNotification.SetActive(false);
            }
            gs.enabled = true;
            Delivery.sortingOrder = deliverySorting;
        }
        else
        {
            crossEmail.SetActive(true);
            Delivery.gameObject.SetActive(true);
            gs.enabled = false;
            Delivery.sortingOrder = deliverySorting + 1;
            OrderCanvas.sortingOrder = orderSorting;
            ShopCanvas.sortingOrder = shopSorting;
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
            ShopCanvas.sortingOrder = shopSorting;
        }
        else
        {
            ShopCanvas.gameObject.SetActive(true);
            iconShop.SetActive(false);
            crossShop.SetActive(true);
            GameManagerScript.instance.highlightedTile = new Vector3Int(-500, -500, -500);
            gs.enabled = false;
            ShopCanvas.sortingOrder = shopSorting + 1;
            OrderCanvas.sortingOrder = orderSorting;
            Delivery.sortingOrder = deliverySorting;
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
        dcv.enabled = false;
        GameManagerScript.instance.QuitEndDay();
        SceneManager.LoadScene("Menu");
    }

    //quits game
    public void OnClickQuit()
    {
        dcv.enabled = false;
        GameManagerScript.instance.QuitEndDay();
        Application.Quit();
    }

    public void CloseConfirm()
    {
        GameManagerScript.instance.sleepConfirmCanvas.SetActive(false);
    }
}
