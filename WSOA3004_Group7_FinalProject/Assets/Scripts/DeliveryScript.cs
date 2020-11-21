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
        //DisplayOrder[0].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderArray[0].LettuceAmount + "/" + GameManagerScript.instance.orderArray[0].LettuceNeeded.ToString();
    }

    public void AcceptOrder(Transform trans)
    {
        int num = (int)trans.gameObject.name[0]; 
        Order order;
        if (GameManagerScript.instance.Email1.activeSelf)
        {
            order = GameManagerScript.instance.displayedOrders[0];
        }
        else
        {
            order = GameManagerScript.instance.displayedOrders[1];
        }
        GameManagerScript.instance.juteBags[num].SetActive(true);
        order.Accepted = true;
        order.Completed = false;
        order.Rejected = false;
        bool done = false;
        for (int a = 0; a < GameManagerScript.instance.acceptedOrders.Length && !done; a++)
        {
            if(GameManagerScript.instance.acceptedOrders[a].OrderText == "")
            {
                GameManagerScript.instance.acceptedOrders[a] = order;
                GameManagerScript.instance.acceptedOrderBool[a] = true;
                done = true;
            }
        }
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

    public void Clicked(Transform trans)
    {
        int num = (int)trans.gameObject.name[0];
        Order activeOrder = GameManagerScript.instance.acceptedOrders[num];
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
                GameManagerScript.instance.juteBags[num].SetActive(false);
                GameObject jute = GameManagerScript.instance.juteBags[num];
                jute.transform.Find("closed").gameObject.SetActive(true);
                activeOrder.Completed = true;
                GameManagerScript.instance.Funds += activeOrder.Reward;
                activeOrder.TotalFunds += activeOrder.Reward;
                GameManagerScript.instance.notebookNoOrders.SetActive(true);
                GameManagerScript.instance.orderDescription.SetActive(false);
            }
        }
    }
}
