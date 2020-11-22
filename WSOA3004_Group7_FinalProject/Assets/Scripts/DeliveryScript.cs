using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryScript : MonoBehaviour
{
    public GameObject[] DisplayOrderLettuce = new GameObject[10];
    public GameObject[] DisplayOrderPotato = new GameObject[10];
    public GameObject[] DisplayOrderTurnip = new GameObject[10];
    public GameObject[] DisplayOrderWatermelon = new GameObject[10];
    public GameObject[] DisplayOrderCarrot = new GameObject[10];
    public Text orderText;
    public GameObject noEmail;

    // Start is called before the first frame update
    void Start()
    {
        noEmail.SetActive(false);
        JuteCanvasDisplayers();
    }

    void JuteCanvasDisplayers()
    {
        for (int a = 0; a < GameManagerScript.instance.acceptedOrders.Length; a++)
        {
            DisplayOrderLettuce[a].GetComponentInChildren<Text>().text = GameManagerScript.instance.acceptedOrders[a].LettuceAmount + "/" + GameManagerScript.instance.acceptedOrders[a].LettuceNeeded.ToString();
            DisplayOrderPotato[a].GetComponentInChildren<Text>().text = GameManagerScript.instance.acceptedOrders[a].PotatoAmount + "/" + GameManagerScript.instance.acceptedOrders[a].PotatoNeeded.ToString();
            DisplayOrderTurnip[a].GetComponentInChildren<Text>().text = GameManagerScript.instance.acceptedOrders[a].TurnipAmount + "/" + GameManagerScript.instance.acceptedOrders[a].TurnipNeeded.ToString();
            DisplayOrderWatermelon[a].GetComponentInChildren<Text>().text = GameManagerScript.instance.acceptedOrders[a].WatermelonAmount + "/" + GameManagerScript.instance.acceptedOrders[a].WatermelonNeeded.ToString();
            DisplayOrderCarrot[a].GetComponentInChildren<Text>().text = GameManagerScript.instance.acceptedOrders[a].CarrotAmount + "/" + GameManagerScript.instance.acceptedOrders[a].CarrotNeeded.ToString();
        }
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

        order.Accepted = true;
        order.Completed = false;
        order.Rejected = false;
        bool done = false;
        for (int a = 0; a < GameManagerScript.instance.acceptedOrders.Length && !done; a++)
        {
            if(GameManagerScript.instance.acceptedOrders[a].OrderText == "")
            {
                GameManagerScript.instance.acceptedOrders[a].OrderText = order.OrderText;
                GameManagerScript.instance.acceptedOrders[a].nameOrder = order.nameOrder;
                GameManagerScript.instance.acceptedOrders[a].TotalFunds = order.TotalFunds;
                GameManagerScript.instance.acceptedOrders[a].DaysAllocated = order.DaysAllocated;
                GameManagerScript.instance.acceptedOrders[a].DaysPassed = order.DaysPassed;
                GameManagerScript.instance.acceptedOrders[a].Reward = order.Reward;
                GameManagerScript.instance.acceptedOrders[a].Accepted = order.Accepted;
                GameManagerScript.instance.acceptedOrders[a].Rejected = order.Rejected;
                GameManagerScript.instance.acceptedOrders[a].Completed = order.Completed;
                GameManagerScript.instance.acceptedOrders[a].Delivered = order.Delivered;
                GameManagerScript.instance.acceptedOrders[a].TurnipNeeded = order.TurnipNeeded;
                GameManagerScript.instance.acceptedOrders[a].WatermelonNeeded = order.WatermelonNeeded;
                GameManagerScript.instance.acceptedOrders[a].CarrotNeeded = order.CarrotNeeded;
                GameManagerScript.instance.acceptedOrders[a].PotatoNeeded = order.PotatoAmount;
                GameManagerScript.instance.acceptedOrders[a].LettuceNeeded = order.LettuceNeeded;
                GameManagerScript.instance.acceptedOrders[a].TurnipAmount = order.TurnipAmount;
                GameManagerScript.instance.acceptedOrders[a].WatermelonAmount = order.WatermelonAmount;
                GameManagerScript.instance.acceptedOrders[a].CarrotAmount = order.CarrotAmount;
                GameManagerScript.instance.acceptedOrders[a].PotatoAmount = order.PotatoAmount;
                GameManagerScript.instance.acceptedOrders[a].LettuceAmount = order.LettuceAmount;
                GameManagerScript.instance.acceptedOrderBool[a] = true;
                done = true;
            }
        }

        int num = 0;

        for (int a = 0; a < GameManagerScript.instance.acceptedOrders.Length; a++)
        {
            if (GameManagerScript.instance.displayedOrders[0].OrderText == GameManagerScript.instance.acceptedOrders[a].OrderText)
            {
                num = a;
            }
            else if (GameManagerScript.instance.displayedOrders[1].OrderText == GameManagerScript.instance.acceptedOrders[a].OrderText)
            {
                num = a;
            }
        }

        GameManagerScript.instance.juteBags[num].SetActive(true);
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
        GameManagerScript.instance.SetupNotebook();
        GameManagerScript.instance.DisplayNotebook();
        JuteCanvasDisplayers();
    }

    public void Clicked(Transform trans)
    {
        int num = (int)char.GetNumericValue(trans.gameObject.name[0]);
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
                    DisplayOrderLettuce[num].GetComponentInChildren<Text>().text = activeOrder.LettuceAmount.ToString() + "/" + activeOrder.LettuceNeeded.ToString();
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
                    DisplayOrderTurnip[num].GetComponentInChildren<Text>().text = activeOrder.TurnipAmount.ToString() + "/" + activeOrder.TurnipNeeded.ToString();
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
                    DisplayOrderPotato[num].GetComponentInChildren<Text>().text = activeOrder.PotatoAmount.ToString() + "/" + activeOrder.PotatoNeeded.ToString();
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
                    DisplayOrderWatermelon[num].GetComponentInChildren<Text>().text = activeOrder.WatermelonAmount.ToString() + "/" + activeOrder.WatermelonNeeded.ToString();
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
                    DisplayOrderCarrot[num].GetComponentInChildren<Text>().text = activeOrder.CarrotAmount.ToString() + "/" + activeOrder.CarrotNeeded.ToString();
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
                GameManagerScript.instance.noNotebookOrders.SetActive(true);
                GameManagerScript.instance.orderDescription.SetActive(false);
            }
        }
    }
}
