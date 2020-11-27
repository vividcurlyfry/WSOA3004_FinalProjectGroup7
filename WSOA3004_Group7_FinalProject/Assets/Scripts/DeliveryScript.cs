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
    public GameObject[] DisplayOrderName = new GameObject[10];
    public Transform[] JPSTransforms = new Transform[10];
    public ParticleSystem JPS;
    public Text orderText;
    public GameObject noEmail;
    public Scrollbar scrollVert;
    public AudioSource AS;
    public AudioClip jute;

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
            if (GameManagerScript.instance.acceptedOrderBool[a])
            {
                DisplayOrderName[a].GetComponentInChildren<Text>().text = GameManagerScript.instance.acceptedOrders[a].nameOrder;
                if (GameManagerScript.instance.acceptedOrders[a].LettuceNeeded != 0)
                {
                    DisplayOrderLettuce[a].GetComponentInChildren<Text>().text = GameManagerScript.instance.acceptedOrders[a].LettuceAmount + "/" + GameManagerScript.instance.acceptedOrders[a].LettuceNeeded.ToString();
                    DisplayOrderLettuce[a].SetActive(true);

                }
                else
                {
                    DisplayOrderLettuce[a].SetActive(false);
                }

                if (GameManagerScript.instance.acceptedOrders[a].PotatoNeeded != 0)
                {
                    DisplayOrderPotato[a].GetComponentInChildren<Text>().text = GameManagerScript.instance.acceptedOrders[a].PotatoAmount + "/" + GameManagerScript.instance.acceptedOrders[a].PotatoNeeded.ToString();
                    DisplayOrderPotato[a].SetActive(true);
                }
                else
                {
                    DisplayOrderPotato[a].SetActive(false);
                }

                if (GameManagerScript.instance.acceptedOrders[a].TurnipNeeded != 0)
                {
                    DisplayOrderTurnip[a].GetComponentInChildren<Text>().text = GameManagerScript.instance.acceptedOrders[a].TurnipAmount + "/" + GameManagerScript.instance.acceptedOrders[a].TurnipNeeded.ToString();
                    DisplayOrderTurnip[a].SetActive(true);
                }
                else
                {
                    DisplayOrderTurnip[a].SetActive(false);
                }

                if (GameManagerScript.instance.acceptedOrders[a].WatermelonNeeded != 0)
                {
                    DisplayOrderWatermelon[a].GetComponentInChildren<Text>().text = GameManagerScript.instance.acceptedOrders[a].WatermelonAmount + "/" + GameManagerScript.instance.acceptedOrders[a].WatermelonNeeded.ToString();
                    DisplayOrderWatermelon[a].SetActive(true);
                }
                else
                {
                    DisplayOrderWatermelon[a].SetActive(false);
                }

                if (GameManagerScript.instance.acceptedOrders[a].CarrotNeeded != 0)
                {
                    DisplayOrderCarrot[a].GetComponentInChildren<Text>().text = GameManagerScript.instance.acceptedOrders[a].CarrotAmount + "/" + GameManagerScript.instance.acceptedOrders[a].CarrotNeeded.ToString();
                    DisplayOrderCarrot[a].SetActive(true);
                }
                else
                {
                    DisplayOrderCarrot[a].SetActive(false);
                }
            }
        }
    }

    public void AcceptOrder()
    {
        scrollVert.value = 1;
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
            if(!GameManagerScript.instance.acceptedOrderBool[a])
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
                GameManagerScript.instance.acceptedOrders[a].PotatoNeeded = order.PotatoNeeded;
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

        for (int a = 0; a < GameManagerScript.instance.acceptedOrders.Length; a++)
        {
            if (GameManagerScript.instance.acceptedOrderBool[a] && !GameManagerScript.instance.acceptedOrders[a].Completed) 
            {
                GameManagerScript.instance.juteBags[a].SetActive(true);
            }
            else if (GameManagerScript.instance.acceptedOrderBool[a] && GameManagerScript.instance.acceptedOrders[a].Completed && !GameManagerScript.instance.acceptedOrders[a].Delivered)
            {
                GameManagerScript.instance.juteBags[a].SetActive(false);
                GameManagerScript.instance.closedJute[a].SetActive(true);
            }
            else
            {
                GameManagerScript.instance.juteBags[a].SetActive(false);
                GameManagerScript.instance.closedJute[a].SetActive(false);
            }
        }

        CloseEmails();
    }

    public void RejectOrder()
    {
        scrollVert.value = 1;
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
            GameManagerScript.instance.prevEmail.SetActive(false);
            GameManagerScript.instance.nextEmail.SetActive(false);
        }
        else
        {
            if ((GameManagerScript.instance.displayedOrders[0].Rejected || GameManagerScript.instance.displayedOrders[0].Accepted) && GameManagerScript.instance.Email1.activeSelf)
            {
                if (GameManagerScript.instance.displayedOrders[1].Reward != 0)
                {
                    GameManagerScript.instance.Email2.SetActive(true);
                    GameManagerScript.instance.Email1.SetActive(false);
                    noEmail.SetActive(false);
                    GameManagerScript.instance.prevEmail.SetActive(false);
                    GameManagerScript.instance.nextEmail.SetActive(false);
                }
                else if (GameManagerScript.instance.displayedOrders[1].Reward == 0)
                {
                    GameManagerScript.instance.Email1.SetActive(false);
                    GameManagerScript.instance.Email2.SetActive(false);
                    noEmail.SetActive(true);
                    GameManagerScript.instance.prevEmail.SetActive(false);
                    GameManagerScript.instance.nextEmail.SetActive(false);
                } 
            }
            else if ((GameManagerScript.instance.displayedOrders[1].Rejected || GameManagerScript.instance.displayedOrders[1].Accepted) && GameManagerScript.instance.Email2.activeSelf)
            {
                if (GameManagerScript.instance.displayedOrders[0].Reward != 0)
                {
                    GameManagerScript.instance.Email1.SetActive(true);
                    GameManagerScript.instance.Email2.SetActive(false);
                    noEmail.SetActive(false);
                    GameManagerScript.instance.prevEmail.SetActive(false);
                    GameManagerScript.instance.nextEmail.SetActive(false);
                }
                else if (GameManagerScript.instance.displayedOrders[0].Reward == 0)
                {
                    GameManagerScript.instance.Email2.SetActive(false);
                    GameManagerScript.instance.Email1.SetActive(false);
                    noEmail.SetActive(true);
                    GameManagerScript.instance.prevEmail.SetActive(false);
                    GameManagerScript.instance.nextEmail.SetActive(false);
                }
            } 
            
        }
        GameManagerScript.instance.SetupNotebook();
        GameManagerScript.instance.DisplayNotebook();
        JuteCanvasDisplayers();
    }

    public void Clicked(Transform trans)
    {
        int num = (int)char.GetNumericValue(trans.gameObject.name[0]);
        if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite != null)
        {
            if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.LettuceSeed.FullyGrownSprite)
            {
                if (  GameManagerScript.instance.acceptedOrders[num-1].LettuceNeeded != 0 &&   GameManagerScript.instance.acceptedOrders[num-1].LettuceAmount !=   GameManagerScript.instance.acceptedOrders[num-1].LettuceNeeded)
                {
                      GameManagerScript.instance.acceptedOrders[num-1].LettuceAmount++;

                    int pos = GameManagerScript.instance.FindPos("Lettuce");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFuncNoSort();
                    DisplayOrderLettuce[num].GetComponentInChildren<Text>().text =   GameManagerScript.instance.acceptedOrders[num-1].LettuceAmount.ToString() + "/" +   GameManagerScript.instance.acceptedOrders[num-1].LettuceNeeded.ToString();
                }
            }

            else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.TurnipSeed.FullyGrownSprite)
            {
                if (  GameManagerScript.instance.acceptedOrders[num-1].TurnipNeeded != 0 &&   GameManagerScript.instance.acceptedOrders[num-1].TurnipAmount !=   GameManagerScript.instance.acceptedOrders[num-1].TurnipNeeded)
                {
                      GameManagerScript.instance.acceptedOrders[num-1].TurnipAmount++;

                    int pos = GameManagerScript.instance.FindPos("Turnip");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFuncNoSort();
                    DisplayOrderTurnip[num].GetComponentInChildren<Text>().text =   GameManagerScript.instance.acceptedOrders[num-1].TurnipAmount.ToString() + "/" +   GameManagerScript.instance.acceptedOrders[num-1].TurnipNeeded.ToString();
                }
            }

            else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.PotatoSeed.FullyGrownSprite)
            {
                if (  GameManagerScript.instance.acceptedOrders[num-1].PotatoNeeded != 0 &&   GameManagerScript.instance.acceptedOrders[num-1].PotatoAmount !=   GameManagerScript.instance.acceptedOrders[num-1].PotatoNeeded)
                {
                      GameManagerScript.instance.acceptedOrders[num-1].PotatoAmount++;

                    int pos = GameManagerScript.instance.FindPos("Potato");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFuncNoSort();
                    DisplayOrderPotato[num].GetComponentInChildren<Text>().text =   GameManagerScript.instance.acceptedOrders[num-1].PotatoAmount.ToString() + "/" +   GameManagerScript.instance.acceptedOrders[num-1].PotatoNeeded.ToString();
                }
            }

            else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.WatermelonSeed.FullyGrownSprite)
            {
                if (  GameManagerScript.instance.acceptedOrders[num-1].WatermelonNeeded != 0 &&   GameManagerScript.instance.acceptedOrders[num-1].WatermelonAmount !=   GameManagerScript.instance.acceptedOrders[num-1].WatermelonNeeded)
                {
                      GameManagerScript.instance.acceptedOrders[num-1].WatermelonAmount++;

                    int pos = GameManagerScript.instance.FindPos("Watermelon");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFuncNoSort();
                    DisplayOrderWatermelon[num].GetComponentInChildren<Text>().text =   GameManagerScript.instance.acceptedOrders[num-1].WatermelonAmount.ToString() + "/" +   GameManagerScript.instance.acceptedOrders[num-1].WatermelonNeeded.ToString();
                }
            }

            else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.CarrotSeed.FullyGrownSprite)
            {
                if (  GameManagerScript.instance.acceptedOrders[num-1].CarrotNeeded != 0 &&   GameManagerScript.instance.acceptedOrders[num-1].CarrotAmount !=   GameManagerScript.instance.acceptedOrders[num-1].CarrotNeeded)
                {
                      GameManagerScript.instance.acceptedOrders[num-1].CarrotAmount++;

                    int pos = GameManagerScript.instance.FindPos("Carrot");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFuncNoSort();
                    DisplayOrderCarrot[num].GetComponentInChildren<Text>().text =   GameManagerScript.instance.acceptedOrders[num-1].CarrotAmount.ToString() + "/" +   GameManagerScript.instance.acceptedOrders[num-1].CarrotNeeded.ToString();
                }
            }

            if (((  GameManagerScript.instance.acceptedOrders[num-1].CarrotAmount ==   GameManagerScript.instance.acceptedOrders[num-1].CarrotNeeded) && (  GameManagerScript.instance.acceptedOrders[num-1].TurnipAmount ==   GameManagerScript.instance.acceptedOrders[num-1].TurnipNeeded) && (  GameManagerScript.instance.acceptedOrders[num-1].WatermelonAmount ==   GameManagerScript.instance.acceptedOrders[num-1].WatermelonNeeded) && (  GameManagerScript.instance.acceptedOrders[num-1].LettuceAmount ==   GameManagerScript.instance.acceptedOrders[num-1].LettuceNeeded) && (  GameManagerScript.instance.acceptedOrders[num-1].PotatoAmount ==   GameManagerScript.instance.acceptedOrders[num-1].PotatoNeeded)) && !  GameManagerScript.instance.acceptedOrders[num-1].Delivered)
            {

                GameManagerScript.instance.juteBags[num-1].SetActive(false);
                GameManagerScript.instance.closedJute[num - 1].SetActive(true);
                AS.PlayOneShot(jute);
                JPS.transform.position = JPSTransforms[num - 1].position;
                JPS.Clear();
                JPS.Play();
                  GameManagerScript.instance.acceptedOrders[num-1].Completed = true;
                GameManagerScript.instance.SetupNotebook();
                GameManagerScript.instance.DisplayNotebook();
            }
            JuteCanvasDisplayers();
        }
    }
}
