using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryScript : MonoBehaviour
{
    public GameObject[] DisplayOrder = new GameObject[6];
    public Text orderText;
    public GameObject noEmail;
    public Order order1;
    public Order order2;
    public Order order3;
    public Order order4;
    public Order order5;
    public Order order6;

    // Start is called before the first frame update
    void Start()
    {
        // orderText.text = GameManagerScript.instance.order1.OrderText;
        DisplayOrder[0].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderArray[0].LettuceAmount + "/" + GameManagerScript.instance.orderArray[0].LettuceNeeded.ToString();
        DisplayOrder[1].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderArray[0].PotatoAmount + "/" + GameManagerScript.instance.orderArray[0].PotatoNeeded.ToString();
        DisplayOrder[2].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderArray[0].TurnipAmount + "/" + GameManagerScript.instance.orderArray[0].TurnipNeeded.ToString();
        DisplayOrder[3].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderArray[0].WatermelonAmount + "/" + GameManagerScript.instance.orderArray[0].WatermelonNeeded.ToString();
        DisplayOrder[4].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderArray[0].CarrotAmount + "/" + GameManagerScript.instance.orderArray[0].CarrotNeeded.ToString();
        noEmail.SetActive(false);
    }

    public void AcceptOrder()
    {
        Order order;
        if (GameManagerScript.instance.Email1.activeSelf)
        {
            order = GameManagerScript.instance.displayedOrders[0];
        }
        else
        {
            order = GameManagerScript.instance.displayedOrders[1];
        }
        GameManagerScript.instance.jute.gameObject.SetActive(true);
        order.Accepted = true;
        order.Completed = false;
        order.Rejected = false;
        GameManagerScript.instance.acceptedOrders.Add(order);
        CloseEmails();
    }

    public void RejectOrder()
    {
        Order order;
        if(GameManagerScript.instance.Email1.activeSelf)
        {
            order = GameManagerScript.instance.displayedOrders[0];
        }
        else
        {
            order = GameManagerScript.instance.displayedOrders[1];
        }

        order.Accepted = false;
        order.Completed = false;
        order.Rejected = true;
        CloseEmails();
    }

    public void CloseEmails()
    {
        if ((GameManagerScript.instance.displayedOrders[0].Accepted == true && GameManagerScript.instance.displayedOrders[1].Accepted == true) || (GameManagerScript.instance.displayedOrders[0].Accepted == true && GameManagerScript.instance.displayedOrders[1].Rejected == true) || (GameManagerScript.instance.displayedOrders[0].Rejected == true && GameManagerScript.instance.displayedOrders[1].Accepted == true) || (GameManagerScript.instance.displayedOrders[0].Rejected == true && GameManagerScript.instance.displayedOrders[1].Rejected == true))
        {
            GameManagerScript.instance.MoreAcceptedOrders = false;
            GameManagerScript.instance.scrollView.SetActive(false);
            GameManagerScript.instance.orderDescription.SetActive(true);
            noEmail.SetActive(true);
        }
        else
        {
            if(GameManagerScript.instance.displayedOrders[0].Accepted || GameManagerScript.instance.displayedOrders[0].Rejected)
            {
                GameManagerScript.instance.Email1.SetActive(false);
                GameManagerScript.instance.Email2.SetActive(true);
            }
            else
            {
                GameManagerScript.instance.Email1.SetActive(true);
                GameManagerScript.instance.Email2.SetActive(false);
            }
        }
    }

    public void Clicked(int numOrder)
    {
        Order activeOrder = null;
        if(numOrder == 1)
        {
            activeOrder = order1;
        }
        else if (numOrder == 2)
        {
            activeOrder = order2;
        }
        else if (numOrder == 3)
        {
            activeOrder = order3;
        }
        else if (numOrder == 4)
        {
            activeOrder = order4;
        }
        else if (numOrder == 5)
        {
            activeOrder = order5;
        }
        else if (numOrder == 6)
        {
            activeOrder = order6;
        }

        if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite != null)
        {
            if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.LettuceSeed.FullyGrownSprite)
            {
                if (activeOrder.LettuceNeeded != 0 && activeOrder.LettuceAmount != activeOrder.LettuceNeeded)
                {
                    activeOrder.LettuceAmount++;

                    int pos = GameManagerScript.instance.FindPos("Lettuce");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFuncNoSort();
                    DisplayOrder[0].GetComponentInChildren<Text>().text = activeOrder.LettuceAmount.ToString() + "/" + activeOrder.LettuceNeeded.ToString();
                }
            }

            else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.TurnipSeed.FullyGrownSprite)
            {
                if (activeOrder.TurnipNeeded != 0 && activeOrder.TurnipAmount != activeOrder.TurnipNeeded)
                {
                    activeOrder.TurnipAmount++;

                    int pos = GameManagerScript.instance.FindPos("Turnip");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFuncNoSort();
                    DisplayOrder[2].GetComponentInChildren<Text>().text = activeOrder.TurnipAmount.ToString() + "/" + activeOrder.TurnipNeeded.ToString();
                }
            }

            else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.PotatoSeed.FullyGrownSprite)
            {
                if (activeOrder.PotatoNeeded != 0 && activeOrder.PotatoAmount != activeOrder.PotatoNeeded)
                {
                    activeOrder.PotatoAmount++;

                    int pos = GameManagerScript.instance.FindPos("Potato");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFuncNoSort();
                    DisplayOrder[1].GetComponentInChildren<Text>().text = activeOrder.PotatoAmount.ToString() + "/" + activeOrder.PotatoNeeded.ToString();
                }
            }

            else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.WatermelonSeed.FullyGrownSprite)
            {
                if (activeOrder.WatermelonNeeded != 0 && activeOrder.WatermelonAmount != activeOrder.WatermelonNeeded)
                {
                    activeOrder.WatermelonAmount++;

                    int pos = GameManagerScript.instance.FindPos("Watermelon");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFuncNoSort();
                    DisplayOrder[3].GetComponentInChildren<Text>().text = activeOrder.WatermelonAmount.ToString() + "/" + activeOrder.WatermelonNeeded.ToString();
                }
            }

            else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.CarrotSeed.FullyGrownSprite)
            {
                if (activeOrder.CarrotNeeded != 0 && activeOrder.CarrotAmount != activeOrder.CarrotNeeded)
                {
                    activeOrder.CarrotAmount++;

                    int pos = GameManagerScript.instance.FindPos("Carrot");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFuncNoSort();
                    DisplayOrder[4].GetComponentInChildren<Text>().text = activeOrder.CarrotAmount.ToString() + "/" + activeOrder.CarrotNeeded.ToString();
                }
            }

            if ((activeOrder.CarrotAmount == activeOrder.CarrotNeeded) && (activeOrder.TurnipAmount == activeOrder.TurnipNeeded) && (activeOrder.WatermelonAmount == activeOrder.WatermelonNeeded) && (activeOrder.LettuceAmount == activeOrder.LettuceNeeded) && (activeOrder.PotatoAmount == activeOrder.PotatoNeeded))
            {
                GameManagerScript.instance.jute.SetActive(false);
                GameManagerScript.instance.juteClosed.SetActive(true);
                activeOrder.Completed = true;
                GameManagerScript.instance.Funds += activeOrder.Reward;
                activeOrder.TotalFunds += activeOrder.Reward;
                GameManagerScript.instance.notebookNoOrders.SetActive(true);
                GameManagerScript.instance.orderDescription.SetActive(false);
            }
        }
    }
}
