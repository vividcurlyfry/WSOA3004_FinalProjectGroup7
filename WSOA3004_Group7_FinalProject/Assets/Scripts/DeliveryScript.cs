using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryScript : MonoBehaviour
{
    public GameObject[] DisplayOrder = new GameObject[6];
    public Text orderText;
    public GameObject noEmail;

    // Start is called before the first frame update
    void Start()
    {
       // orderText.text = GameManagerScript.instance.order1.OrderText;
        DisplayOrder[0].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderArray[0].LettuceAmount + "/" + GameManagerScript.instance.orderArray[0].LettuceNeeded.ToString();
        DisplayOrder[1].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderArray[0].PotatoAmount + "/" + GameManagerScript.instance.orderArray[0].PotatoNeeded.ToString();
        DisplayOrder[2].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderArray[0].TurnipAmount + "/" + GameManagerScript.instance.orderArray[0].TurnipNeeded.ToString();
        DisplayOrder[3].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderArray[0].WatermelonAmount + "/" + GameManagerScript.instance.orderArray[0].WatermelonNeeded.ToString();
        DisplayOrder[4].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderArray[0].CarrotAmount + "/" + GameManagerScript.instance.orderArray[0].CarrotNeeded.ToString();
        DisplayOrder[5].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderArray[0].PeachAmount + "/" + GameManagerScript.instance.orderArray[0].PeachNeeded.ToString();
        noEmail.SetActive(false);
    }

    public void AcceptOrder()
    {
        GameManagerScript.instance.jute.gameObject.SetActive(true);
        GameManagerScript.instance.MoreAcceptedOrders = false;
        GameManagerScript.instance.orderNameText.text = "Maya Wolff";
        GameManagerScript.instance.sv.SetActive(false);
        GameManagerScript.instance.orderDescription.SetActive(true);
        noEmail.SetActive(true);
        GameManagerScript.instance.orderList[0].Accepted = true;
        GameManagerScript.instance.orderList[0].Completed = false;
        GameManagerScript.instance.DaysOrderLeft.text = (GameManagerScript.instance.orderList[0].DaysAllocated - GameManagerScript.instance.orderList[0].DaysPassed).ToString();
    }

    public void RejectOrder()
    {
        GameManagerScript.instance.sv.SetActive(false);
        noEmail.SetActive(true);
        GameManagerScript.instance.orderList[0].Accepted = false;
        GameManagerScript.instance.orderList[0].Completed = false;
        GameManagerScript.instance.MoreAcceptedOrders = false;
    }

    public void Clicked()
    {
        if(GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite != null)
        {
            if(GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.LettuceSeed.FullyGrownSprite)
            {
                if(GameManagerScript.instance.orderList[0].LettuceNeeded != 0 && GameManagerScript.instance.orderList[0].LettuceAmount != GameManagerScript.instance.orderList[0].LettuceNeeded)
                {
                    GameManagerScript.instance.orderList[0].LettuceAmount++;

                    int pos = GameManagerScript.instance.FindPos("Lettuce");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFuncNoSort();
                    DisplayOrder[0].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderList[0].LettuceAmount.ToString() + "/" + GameManagerScript.instance.orderList[0].LettuceNeeded.ToString();
                }
            }

            else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.TurnipSeed.FullyGrownSprite)
            {
                if (GameManagerScript.instance.orderList[0].TurnipNeeded != 0 && GameManagerScript.instance.orderList[0].TurnipAmount != GameManagerScript.instance.orderList[0].TurnipNeeded)
                {
                    GameManagerScript.instance.orderList[0].TurnipAmount++;

                    int pos = GameManagerScript.instance.FindPos("Turnip");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFuncNoSort();
                    DisplayOrder[2].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderList[0].TurnipAmount.ToString() + "/" + GameManagerScript.instance.orderList[0].TurnipNeeded.ToString();
                }
            }

            else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.PotatoSeed.FullyGrownSprite)
            {
                if (GameManagerScript.instance.orderList[0].PotatoNeeded != 0 && GameManagerScript.instance.orderList[0].PotatoAmount != GameManagerScript.instance.orderList[0].PotatoNeeded)
                {
                    GameManagerScript.instance.orderList[0].PotatoAmount++;

                    int pos = GameManagerScript.instance.FindPos("Potato");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFuncNoSort();
                    DisplayOrder[1].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderList[0].PotatoAmount.ToString() + "/" + GameManagerScript.instance.orderList[0].PotatoNeeded.ToString();
                }
            }

            else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.WatermelonSeed.FullyGrownSprite)
            {
                if (GameManagerScript.instance.orderList[0].WatermelonNeeded != 0 && GameManagerScript.instance.orderList[0].WatermelonAmount != GameManagerScript.instance.orderList[0].WatermelonNeeded)
                {
                    GameManagerScript.instance.orderList[0].WatermelonAmount++;

                    int pos = GameManagerScript.instance.FindPos("Watermelon");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFuncNoSort();
                    DisplayOrder[3].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderList[0].WatermelonAmount.ToString() + "/" + GameManagerScript.instance.orderList[0].WatermelonNeeded.ToString();
                }
            }

            else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.CarrotSeed.FullyGrownSprite)
            {
                if (GameManagerScript.instance.orderList[0].CarrotNeeded != 0 && GameManagerScript.instance.orderList[0].CarrotAmount != GameManagerScript.instance.orderList[0].CarrotNeeded)
                {
                    GameManagerScript.instance.orderList[0].CarrotAmount++;

                    int pos = GameManagerScript.instance.FindPos("Carrot");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFuncNoSort();
                    DisplayOrder[4].GetComponentInChildren<Text>().text = GameManagerScript.instance.orderList[0].CarrotAmount.ToString() + "/" + GameManagerScript.instance.orderList[0].CarrotNeeded.ToString();
                }
            }

            if((GameManagerScript.instance.orderList[0].CarrotAmount == GameManagerScript.instance.orderList[0].CarrotNeeded) && (GameManagerScript.instance.orderList[0].TurnipAmount == GameManagerScript.instance.orderList[0].TurnipNeeded) && (GameManagerScript.instance.orderList[0].WatermelonAmount == GameManagerScript.instance.orderList[0].WatermelonNeeded) && (GameManagerScript.instance.orderList[0].LettuceAmount == GameManagerScript.instance.orderList[0].LettuceNeeded) && (GameManagerScript.instance.orderList[0].PotatoAmount == GameManagerScript.instance.orderList[0].PotatoNeeded))
            {
                GameManagerScript.instance.jute.SetActive(false);
                GameManagerScript.instance.juteClosed.SetActive(true);
                GameManagerScript.instance.orderList[0].Completed = true;
                GameManagerScript.instance.Funds += GameManagerScript.instance.orderList[0].Reward;
                GameManagerScript.instance.orderList[0].TotalFunds += GameManagerScript.instance.orderList[0].Reward;
                GameManagerScript.instance.NoOrders.SetActive(true);
                GameManagerScript.instance.orderDescription.SetActive(false);
            }
        }
    }
}
