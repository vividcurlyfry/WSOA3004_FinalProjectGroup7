using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;
    public Vector3Int highlightedTile;
    public int DaysPlayed;

    public bool NearBed = false;

    public GameObject SelectedObj;
    public int Funds;
    public InventoryObject Inventory;
    public GameObject[] DisplayInven = new GameObject[6];
    public int[] InventorySave;
    public Text FundsText;
    public bool isRaining;

    public GameObject jute;
    public GameObject juteClosed;

    public Order[] orderArray;
    public List<Order> orderList;
    public List<Order> displayedOrders;
    public List<Order> acceptedOrders;
    public GameObject[] emailObjects;
    public Text veggiesStory;

    public Crop LettuceSeed;
    public Crop PotatoSeed;
    public Crop TurnipSeed;
    public Crop WatermelonSeed;
    public Crop CarrotSeed;

    public Tool Hoe;
    public Tool WateringCan;
    public Tool Scythe;

    public GameObject highlight;
    public int PosInven;

    public TileBase[] tmState;
    public Tilemap tm_base;
    public Tilemap tm_water;

    public Tile Watered;

    public bool MoreAcceptedOrders;

    public GameObject orderNotification;
    public Text orderNameText;
    public GameObject scrollView;

    public GameObject Email1;
    public GameObject Email2;
    public Text emailOrderStory1;
    public Text emailVeggiesNeeded1;
    public Text emailRewardText1;

    public Text emailOrderStory2;
    public Text emailVeggiesNeeded2;
    public Text emailRewardText2;

    public GameObject notebookNoOrders;

    public GameObject sleepConfirmCanvas;

    public GameObject cross;
    public GameObject tick;
    public GameObject line;

    public GameObject orderDescription;

    public Text DaysOrderLeft;

    public bool dayOver = false;

    public float percentageFunds = 75 / 100;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        isRaining = gameObject.GetComponent<LivelinessEffects>().Raining;
        NearBed = false;
        sleepConfirmCanvas.SetActive(false);
        orderDescription.SetActive(false);
        dayOver = false;
        Email2.SetActive(false);

        if (Slot.instance.ActiveSlot == 1 && (PlayerPrefs.GetString("DayOnePlayedSlotOne?") != "yes"))
        {
            DayOne();
        }
        else if (Slot.instance.ActiveSlot == 2 && (PlayerPrefs.GetString("DayOnePlayedSlotTwo?") != "yes"))
        {
            DayOne();
        }
        else if (Slot.instance.ActiveSlot == 3 && (PlayerPrefs.GetString("DayOnePlayedSlotThree?") != "yes"))
        {
            DayOne();
        }
        else if (Slot.instance.ActiveSlot == 4 && (PlayerPrefs.GetString("DayOnePlayedSlotFour?") != "yes"))
        {
            DayOne();
        }
        else
        {
            LoadGame();
            if (LettuceSeed.PlantedLocations.Count != 0)
            {
                for (int a = 0; a < LettuceSeed.PlantedLocations.Count; a++)
                {
                    if (isRaining == true)
                    {
                        tm_water.SetTile(LettuceSeed.PlantedLocations[a], Watered);
                        LettuceSeed.Watered[a] = true;
                    }
                    else
                    {
                        LettuceSeed.Watered[a] = false;
                    }

                    if (LettuceSeed.DaysGrown[a] <= LettuceSeed.DaysToGrow)
                    {
                        tm_base.SetTile(LettuceSeed.PlantedLocations[a], LettuceSeed.GrowingTiles[LettuceSeed.DaysGrown[a]]);
                    }
                    else
                    {
                        tm_base.SetTile(LettuceSeed.PlantedLocations[a], LettuceSeed.GrowingTiles[LettuceSeed.DaysToGrow]);
                    }
                }
            }

            if (TurnipSeed.PlantedLocations.Count != 0)
            {
                for (int a = 0; a < TurnipSeed.PlantedLocations.Count; a++)
                {
                    if (isRaining == true)
                    {
                        tm_water.SetTile(TurnipSeed.PlantedLocations[a], Watered);
                        TurnipSeed.Watered[a] = true;
                    }
                    else
                    {
                        TurnipSeed.Watered[a] = false;
                    }

                    if (TurnipSeed.DaysGrown[a] <= TurnipSeed.DaysToGrow)
                    {
                        tm_base.SetTile(TurnipSeed.PlantedLocations[a], TurnipSeed.GrowingTiles[TurnipSeed.DaysGrown[a]]);
                    }
                    else
                    {
                        tm_base.SetTile(TurnipSeed.PlantedLocations[a], TurnipSeed.GrowingTiles[TurnipSeed.DaysToGrow]);
                    }
                }
            }

            if (PotatoSeed.PlantedLocations.Count != 0)
            {
                for (int a = 0; a < PotatoSeed.PlantedLocations.Count; a++)
                {
                    if (isRaining == true)
                    {
                        tm_water.SetTile(PotatoSeed.PlantedLocations[a], Watered);
                        PotatoSeed.Watered[a] = true;
                    }
                    else
                    {
                        PotatoSeed.Watered[a] = false;
                    }
                    if (PotatoSeed.DaysGrown[a] <= PotatoSeed.DaysToGrow)
                    {
                        tm_base.SetTile(PotatoSeed.PlantedLocations[a], PotatoSeed.GrowingTiles[PotatoSeed.DaysGrown[a]]);
                    }
                    else
                    {
                        tm_base.SetTile(PotatoSeed.PlantedLocations[a], PotatoSeed.GrowingTiles[PotatoSeed.DaysToGrow]);
                    }
                }
            }

            if (CarrotSeed.PlantedLocations.Count != 0)
            {
                for (int a = 0; a < CarrotSeed.PlantedLocations.Count; a++)
                {
                    if (isRaining == true)
                    {
                        tm_water.SetTile(CarrotSeed.PlantedLocations[a], Watered);
                        CarrotSeed.Watered[a] = true;
                    }
                    else
                    {
                        CarrotSeed.Watered[a] = false;
                    }
                    if (CarrotSeed.DaysGrown[a] <= CarrotSeed.DaysToGrow)
                    {
                        tm_base.SetTile(CarrotSeed.PlantedLocations[a], CarrotSeed.GrowingTiles[CarrotSeed.DaysGrown[a]]);
                    }
                    else
                    {
                        tm_base.SetTile(CarrotSeed.PlantedLocations[a], CarrotSeed.GrowingTiles[CarrotSeed.DaysToGrow]);
                    }
                }
            }

            if (WatermelonSeed.PlantedLocations.Count != 0)
            {
                for (int a = 0; a < WatermelonSeed.PlantedLocations.Count; a++)
                {
                    if (isRaining == true)
                    {
                        tm_water.SetTile(WatermelonSeed.PlantedLocations[a], Watered);
                        WatermelonSeed.Watered[a] = true;
                    }
                    else
                    {
                        WatermelonSeed.Watered[a] = false;
                    }
                    if (WatermelonSeed.DaysGrown[a] <= WatermelonSeed.DaysToGrow)
                    {
                        tm_base.SetTile(WatermelonSeed.PlantedLocations[a], WatermelonSeed.GrowingTiles[WatermelonSeed.DaysGrown[a]]);
                    }
                    else
                    {
                        tm_base.SetTile(WatermelonSeed.PlantedLocations[a], WatermelonSeed.GrowingTiles[WatermelonSeed.DaysToGrow]);
                    }
                }
            }
        }

        if (orderList.Count > 0)
        {
            orderNotification.SetActive(true);
        }
        else
        {
            orderNotification.SetActive(false);
        }

        //for (int f = 0; f < displayedOrders.Count; f++)
        //{
        if (orderList[0].Accepted)
        {
            orderDescription.SetActive(true);
            notebookNoOrders.SetActive(true);
            orderNameText.text = orderList[0].name;
            if (orderList[0].DaysPassed > orderList[0].DaysAllocated && !orderList[0].Completed)
            {
                jute.SetActive(false);
                orderList[0].CarrotAmount = 0;
                orderList[0].TurnipAmount = 0;
                orderList[0].WatermelonAmount = 0;
                orderList[0].PotatoAmount = 0;
                orderList[0].LettuceAmount = 0;
                cross.SetActive(true);
                tick.SetActive(false);
                line.SetActive(true);
                DaysOrderLeft.text = "0";
            }
            else if (orderList[0].DaysPassed > orderList[0].DaysAllocated && orderList[0].Completed)
            {
                jute.SetActive(false);
                tick.SetActive(true);
                cross.SetActive(false);
                line.SetActive(true);
                DaysOrderLeft.text = "0";
            }
            else
            {
                tick.SetActive(false);
                cross.SetActive(false);
                jute.SetActive(true);
                DaysOrderLeft.text = (orderList[0].DaysAllocated - orderList[0].DaysPassed).ToString();
            }
        }
        // }
        else
        {
            tick.SetActive(false);
            cross.SetActive(false);
            jute.SetActive(false);
            notebookNoOrders.SetActive(true);
            orderDescription.SetActive(false);
        }

        if (orderList[0].Completed && orderList[0].Delivered)
        {
            jute.SetActive(false);
            juteClosed.SetActive(false);
            line.SetActive(true);
            tick.SetActive(true);
        }
        else if (orderList[0].Completed && !orderList[0].Delivered)
        {
            jute.SetActive(false);
            juteClosed.SetActive(true);
            line.SetActive(false);
            tick.SetActive(false);
        }

        juteClosed.SetActive(false);
        DisplayInvenFunc();
        EmailGenerator();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if ((PosInven + 6) < Inventory.inven.Length)
            {
                TabFunc();
            }
            else if (PosInven + 6 >= Inventory.inven.Length)
            {
                PosInven = -6;
                TabFunc();
            }
        }
    }

    public void EmailGenerator()
    {
        if ((DaysPlayed % 3) == 0)
        {
            orderList.Clear();
            for (int l = 0; l < orderArray.Length; l++)
            {
                orderArray[l].CarrotAmount = 0;
                orderArray[l].LettuceAmount = 0;
                orderArray[l].PotatoAmount = 0;
                orderArray[l].TurnipAmount = 0;
                orderArray[l].WatermelonAmount = 0;
                orderArray[l].DaysPassed = 0;
                orderArray[l].Completed = false;
                orderArray[l].Accepted = false;
                orderArray[l].Accepted = false;
                orderArray[l].Delivered = false;
                orderArray[l].TotalFunds = Funds;
                orderList.Add(orderArray[l]);
            }
            int ranNum = Random.Range(0, orderList.Count);
            int otherRanNum = orderList.Count - 1 - ranNum;
            displayedOrders.Add(orderList[ranNum]);
            displayedOrders.Add(orderList[otherRanNum]);
            orderList.RemoveAt(ranNum);
            orderList.RemoveAt(otherRanNum);
        }
        else
        {
            int ranNum = Random.Range(0, orderList.Count);
            int otherRanNum = orderList.Count - 1 - ranNum;
            displayedOrders.Add(orderList[ranNum]);
            displayedOrders.Add(orderList[otherRanNum]);
            orderList.RemoveAt(ranNum);
            orderList.RemoveAt(otherRanNum);
        }

        OrderCalc(displayedOrders[displayedOrders.Count - 1],displayedOrders[displayedOrders.Count - 2]);
        DisplayOrderEmail();
    }

    public void OrderCalc(Order order1, Order order2)
    {
        Order order1Backup = order1;
        Order order2Backup = order2;
        float fundCalcFloat = Funds * percentageFunds;
        int fundCalc = (int)fundCalcFloat;
        int maxBelowGround = (int)(fundCalc / 10);

        int belowGround = Random.Range(1, maxBelowGround);
        int maxAboveGround = (int)(fundCalc - 10 * belowGround) / 15;

        int aboveGround = Random.Range(1, maxAboveGround);

        int totalBelowGround = 0;
        int totalAboveGround = 0;

        int order1Reward = 0;
        int order2Reward = 0;

        order1.CarrotNeeded = Random.Range(1, belowGround + 1);
        totalBelowGround += order1.CarrotNeeded;

        if (totalBelowGround != belowGround)
        {
            order1.PotatoNeeded = Random.Range(1, belowGround - totalBelowGround);
        }

        totalBelowGround += order1.PotatoNeeded;

        if (totalBelowGround != belowGround)
        {
            order1.TurnipNeeded = Random.Range(1, belowGround - totalBelowGround);
        }

        totalBelowGround += order1.TurnipNeeded;

        if (totalBelowGround != belowGround)
        {
            order2.CarrotNeeded = Random.Range(1, belowGround - totalBelowGround);
        }

        totalBelowGround += order2.CarrotNeeded;

        if (totalBelowGround != belowGround)
        {
            order2.PotatoNeeded = Random.Range(1, belowGround - totalBelowGround);
        }

        totalBelowGround += order2.PotatoNeeded;

        if (totalBelowGround != belowGround)
        {
            order2.TurnipNeeded = Random.Range(1, belowGround - totalBelowGround);
        }

        while(totalBelowGround != belowGround)
        {
            if(totalBelowGround != belowGround)
            {
                order1.CarrotNeeded++;
                totalBelowGround++;
            }

            if (totalBelowGround != belowGround)
            {
                order2.CarrotNeeded++;
                totalBelowGround++;
            }

            if (totalBelowGround != belowGround)
            {
                order1.TurnipNeeded++;
                totalBelowGround++;
            }

            if (totalBelowGround != belowGround)
            {
                order2.TurnipNeeded++;
                totalBelowGround++;
            }

            if (totalBelowGround != belowGround)
            {
                order2.PotatoNeeded++;
                totalBelowGround++;
            }

            if (totalBelowGround != belowGround)
            {
                order1.PotatoNeeded++;
                totalBelowGround++;
            }
        }

        order1.LettuceNeeded = Random.Range(1, aboveGround + 1);
        totalAboveGround += order1.LettuceNeeded;

        if (totalAboveGround != aboveGround)
        {
            order1.WatermelonNeeded = Random.Range(1, aboveGround - totalAboveGround);
        }

        totalAboveGround += order1.WatermelonNeeded;

        if (totalAboveGround != aboveGround)
        {
            order2.LettuceNeeded = Random.Range(1, aboveGround - totalAboveGround);
        }

        totalAboveGround += order2.LettuceNeeded;

        if (totalAboveGround != aboveGround)
        {
            order2.WatermelonNeeded = Random.Range(1, aboveGround - totalAboveGround);
        }

        while (totalAboveGround != aboveGround)
        {
            if (totalAboveGround != aboveGround)
            {
                order1.LettuceNeeded++;
                totalAboveGround++;
            }

            if (totalAboveGround != aboveGround)
            {
                order2.LettuceNeeded++;
                totalAboveGround++;
            }

            if (totalAboveGround != aboveGround)
            {
                order2.WatermelonNeeded++;
                totalAboveGround++;
            }

            if (totalAboveGround != aboveGround)
            {
                order1.WatermelonNeeded++;
                totalAboveGround++;
            }
        }

        order1Reward += order1.CarrotNeeded * 15;
        order1Reward += order1.PotatoNeeded * 15;
        order1Reward += order1.TurnipNeeded * 15;
        order1Reward += order1.WatermelonNeeded * 28;
        order1Reward += order1.LettuceNeeded * 28;

        order1.Reward = order1Reward;

        order2Reward += order2.CarrotNeeded * 15;
        order2Reward += order2.PotatoNeeded * 15;
        order2Reward += order2.TurnipNeeded * 15;
        order2Reward += order2.WatermelonNeeded * 28;
        order2Reward += order2.LettuceNeeded * 28;

        order2.Reward = order2Reward;

        if(order1.Reward == 0 || order2.Reward == 0)
        {
            OrderCalc(order1Backup, order2Backup);
        }
    }

    public void DisplayOrderEmail()
    {
        emailOrderStory1.text = displayedOrders[0].OrderText.ToString();
        emailRewardText1.text = displayedOrders[0].Reward.ToString();

        string veggiesNeeded = "";
        if(displayedOrders[0].CarrotNeeded != 0)
        {
            veggiesNeeded = displayedOrders[0].CarrotNeeded.ToString() + " x Carrot(s)";
        }
        if (displayedOrders[0].TurnipNeeded != 0)
        {
            veggiesNeeded += System.Environment.NewLine + displayedOrders[0].TurnipNeeded.ToString() + " x Turnip(s)";
        }
        if (displayedOrders[0].PotatoNeeded != 0)
        {
            veggiesNeeded += System.Environment.NewLine + displayedOrders[0].PotatoNeeded.ToString() + " x Potato(s)";
        }
        if (displayedOrders[0].WatermelonNeeded != 0)
        {
            veggiesNeeded += System.Environment.NewLine + displayedOrders[0].WatermelonNeeded.ToString() + " x Watermelon(s)";
        }
        if (displayedOrders[0].LettuceNeeded != 0)
        {
            veggiesNeeded += System.Environment.NewLine + displayedOrders[0].LettuceNeeded.ToString() + " x Lettuce(s)";
        }
        emailVeggiesNeeded1.text = veggiesNeeded;


        emailOrderStory2.text = displayedOrders[1].OrderText.ToString();
        emailRewardText2.text = displayedOrders[1].Reward.ToString();

        if (displayedOrders[1].CarrotNeeded != 0)
        {
            veggiesNeeded = displayedOrders[1].CarrotNeeded.ToString() + " x Carrot(s)";
        }
        if (displayedOrders[1].TurnipNeeded != 0)
        {
            veggiesNeeded += System.Environment.NewLine + displayedOrders[1].TurnipNeeded.ToString() + " x Turnip(s)";
        }
        if (displayedOrders[1].PotatoNeeded != 0)
        {
            veggiesNeeded += System.Environment.NewLine + displayedOrders[1].PotatoNeeded.ToString() + " x Potato(s)";
        }
        if (displayedOrders[1].WatermelonNeeded != 0)
        {
            veggiesNeeded += System.Environment.NewLine + displayedOrders[1].WatermelonNeeded.ToString() + " x Watermelon(s)";
        }
        if (displayedOrders[1].LettuceNeeded != 0)
        {
            veggiesNeeded += System.Environment.NewLine + displayedOrders[1].LettuceNeeded.ToString() + " x Lettuce(s)";
        }
        emailVeggiesNeeded2.text = veggiesNeeded;
    }

    public void TabFunc()
    {
        if (Inventory.inven[PosInven + 6].ItemNumber != 0)
        {
            for (int a = 0; a < 6; a++)
            {
                DisplayInven[a].GetComponentInChildren<Text>().text = "0";
                DisplayInven[a].GetComponentInChildren<SpriteRenderer>().sprite = null;
            }
            PosInven = PosInven + 6;
            DisplayInvenFunc();
        }
        else
        {
            for (int a = 0; a < 6; a++)
            {
                DisplayInven[a].GetComponentInChildren<Text>().text = "0";
                DisplayInven[a].GetComponentInChildren<SpriteRenderer>().sprite = null;
            }
            PosInven = 0;
            DisplayInvenFunc();
        }
    }

    public void DisplayInvenFunc()
    {

        for (int j = 0; j <= Inventory.inven.Length - 2; j++)
        {
            for (int i = 0; i <= Inventory.inven.Length - 2; i++)
            {
                if ((Inventory.inven[i].ItemNumber < Inventory.inven[i + 1].ItemNumber) && (Inventory.inven[i].ItemName != "Hoe") && (Inventory.inven[i].ItemName != "WateringCan") && (Inventory.inven[i].ItemName != "Scythe"))
                {
                    InventoryClass tmp = Inventory.inven[i];
                    Inventory.inven[i] = Inventory.inven[i + 1];
                    Inventory.inven[i + 1] = tmp;
                }
            }
        }

        for (int i = PosInven; i < Inventory.inven.Length && i < PosInven + 6; i++)
        {
            if (Inventory.inven[i].ItemNumber > 0)
            {
                if ((Inventory.inven[i].ItemName != "Hoe") && (Inventory.inven[i].ItemName != "WateringCan") && (Inventory.inven[i].ItemName != "Scythe"))
                {
                    DisplayInven[i % 6].GetComponentInChildren<Text>().text = Inventory.inven[i].ItemNumber.ToString();
                }
                else
                {
                    DisplayInven[i % 6].GetComponentInChildren<Text>().text = "";
                }
                DisplayInven[i % 6].GetComponentInChildren<SpriteRenderer>().sprite = Inventory.inven[i].ItemSprite;
            }
            else
            {
                DisplayInven[i % 6].GetComponentInChildren<Text>().text = "0";
                DisplayInven[i % 6].GetComponentInChildren<SpriteRenderer>().sprite = null;
            }
        }
    }

    public void DisplayInvenFuncNoSort()
    {

        for (int i = PosInven; i < Inventory.inven.Length && i < PosInven + 6; i++)
        {
            if (Inventory.inven[i].ItemNumber > 0)
            {
                if ((Inventory.inven[i].ItemName != "Hoe") && (Inventory.inven[i].ItemName != "WateringCan") && (Inventory.inven[i].ItemName != "Scythe"))
                {
                    DisplayInven[i % 6].GetComponentInChildren<Text>().text = Inventory.inven[i].ItemNumber.ToString();
                }
                else
                {
                    DisplayInven[i % 6].GetComponentInChildren<Text>().text = "";
                }
                DisplayInven[i % 6].GetComponentInChildren<SpriteRenderer>().sprite = Inventory.inven[i].ItemSprite;
            }
            else
            {
                DisplayInven[i % 6].GetComponentInChildren<Text>().text = "0";
                DisplayInven[i % 6].GetComponentInChildren<SpriteRenderer>().sprite = null;
            }
        }
    }

    public void DayOne()
    {
        Funds = 250;
        LettuceSeed.PlantedLocations.Clear();
        PotatoSeed.PlantedLocations.Clear();
        TurnipSeed.PlantedLocations.Clear();
        WatermelonSeed.PlantedLocations.Clear();
        CarrotSeed.PlantedLocations.Clear();
        LettuceSeed.DaysGrown.Clear();
        PotatoSeed.DaysGrown.Clear();
        TurnipSeed.DaysGrown.Clear();
        WatermelonSeed.DaysGrown.Clear();
        CarrotSeed.DaysGrown.Clear();
        LettuceSeed.Watered.Clear();
        PotatoSeed.Watered.Clear();
        TurnipSeed.Watered.Clear();
        WatermelonSeed.Watered.Clear();
        CarrotSeed.Watered.Clear();
        Hoe.TooledLocations.Clear();
        WateringCan.TooledLocations.Clear();
        Scythe.TooledLocations.Clear();
        WateringCan.TooledLocations.Clear();
        orderList.Clear();
        for (int l = 0; l < orderArray.Length; l++)
        {
            orderArray[l].CarrotAmount = 0;
            orderArray[l].LettuceAmount = 0;
            orderArray[l].PotatoAmount = 0;
            orderArray[l].TurnipAmount = 0;
            orderArray[l].WatermelonAmount = 0;
            orderArray[l].DaysPassed = 0;
            orderArray[l].Completed = false;
            orderArray[l].Accepted = false;
            orderArray[l].Accepted = false;
            orderArray[l].Delivered = false;
            orderArray[l].TotalFunds = 250;
            orderList.Add(orderArray[l]);
        }
        PosInven = 0;
        jute.gameObject.SetActive(false);
        MoreAcceptedOrders = true;
        notebookNoOrders.SetActive(true);
        scrollView.SetActive(true);
        for (int a = 0; a < Inventory.inven.Length; a++)
        {
            if ((Inventory.inven[a].ItemName != "Hoe") && (Inventory.inven[a].ItemName != "WateringCan") && (Inventory.inven[a].ItemName != "Scythe"))
            {
                Inventory.inven[a].ItemNumber = 0;
            }
            else
            {
                Inventory.inven[a].ItemNumber = 1;
            }
        }
    }

    public void SelectObj(RectTransform posButton)
    {
        highlight.transform.position = posButton.transform.position;
        SelectedObj = posButton.transform.gameObject;
    }

    public int FindPos(string name)
    {
        for (int i = 0; i < Inventory.inven.Length; i++)
        {
            if (Inventory.inven[i].ItemName == name)
            {
                return i;
            }
        }
        return -1;
    }

    public void LoadInven()
    {
        InventorySave = new int[Inventory.inven.Length];
        for (int a = 0; a < Inventory.inven.Length; a++)
        {
            InventorySave[a] = Inventory.inven[a].ItemNumber;
        }
    }

    public void SaveInven()
    {
        for (int a = 0; a < Inventory.inven.Length; a++)
        {
            Inventory.inven[a].ItemNumber = InventorySave[a];
        }
    }

    public void DoorEndDay()
    {
        if (NearBed == true)
        {
            sleepConfirmCanvas.SetActive(true);
        }
    }

    public void EndDay()
    {
        DaysPlayed++;
        dayOver = true;
        for (int a = 0; a < displayedOrders.Count; a++)
        {
            orderList[a].TotalFunds = Funds;
            if (orderList[a].Accepted)
            {
                orderList[a].DaysPassed++;
            }
        }
        for (int a = 0; a < LettuceSeed.PlantedLocations.Count; a++)
        {
            if (WateringCan.TooledLocations.Contains(LettuceSeed.PlantedLocations[a]) || isRaining)
            {
                LettuceSeed.Watered[a] = true;
            }
            if (LettuceSeed.Watered[a] == true)
            {
                LettuceSeed.DaysGrown[a]++;
            }
        }

        for (int a = 0; a < TurnipSeed.PlantedLocations.Count; a++)
        {
            if (WateringCan.TooledLocations.Contains(TurnipSeed.PlantedLocations[a]) || isRaining)
            {
                TurnipSeed.Watered[a] = true;
            }
            if (TurnipSeed.Watered[a] == true)
            {
                TurnipSeed.DaysGrown[a]++;
            }
        }

        for (int a = 0; a < WatermelonSeed.PlantedLocations.Count; a++)
        {
            if (WateringCan.TooledLocations.Contains(WatermelonSeed.PlantedLocations[a]) || isRaining)
            {
                WatermelonSeed.Watered[a] = true;
            }
            if (WatermelonSeed.Watered[a] == true)
            {
                WatermelonSeed.DaysGrown[a]++;
            }
        }

        for (int a = 0; a < CarrotSeed.PlantedLocations.Count; a++)
        {
            if (WateringCan.TooledLocations.Contains(CarrotSeed.PlantedLocations[a]) || isRaining)
            {
                CarrotSeed.Watered[a] = true;
            }

            if (CarrotSeed.Watered[a] == true)
            {
                CarrotSeed.DaysGrown[a]++;
            }
        }

        for (int a = 0; a < PotatoSeed.PlantedLocations.Count; a++)
        {
            if (WateringCan.TooledLocations.Contains(PotatoSeed.PlantedLocations[a]) || isRaining)
            {
                PotatoSeed.Watered[a] = true;
            }
            if (PotatoSeed.Watered[a] == true)
            {
                PotatoSeed.DaysGrown[a]++;
            }
        }

        SaveGame();

        if (Slot.instance.ActiveSlot == 1)
        {
            PlayerPrefs.SetString("DayOnePlayedSlotOne?", "yes");
        }
        else if (Slot.instance.ActiveSlot == 2)
        {
            PlayerPrefs.SetString("DayOnePlayedSlotTwo?", "yes");
        }
        else if (Slot.instance.ActiveSlot == 3)
        {
            PlayerPrefs.SetString("DayOnePlayedSlotThree?", "yes");
        }
        else if (Slot.instance.ActiveSlot == 4)
        {
            PlayerPrefs.SetString("DayOnePlayedSlotFour?", "yes");
        }

        if (orderList[0].Completed && !orderList[0].Delivered)
        {
            SceneManager.LoadScene("DayOver");
        }
        else
        {
            //disable planting and stuff
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void SaveGame()
    {
        if (Slot.instance.ActiveSlot == 1)
        {
            GameManagerSaveScript.SaveGameSlotOne(this);
        }
        else if (Slot.instance.ActiveSlot == 2)
        {
            GameManagerSaveScript.SaveGameSlotTwo(this);
        }
        else if (Slot.instance.ActiveSlot == 3)
        {
            GameManagerSaveScript.SaveGameSlotThree(this);
        }
        else if (Slot.instance.ActiveSlot == 4)
        {
            GameManagerSaveScript.SaveGameSlotFour(this);
        }
    }

    public void LoadGame()
    {
        if (Slot.instance.ActiveSlot == 1)
        {
            GameManagerSaveData data = GameManagerSaveScript.LoadGameSlotOne();
            Funds = data.Funds;
            DaysPlayed = data.DaysPlayed;
            InventorySave = data.InventorySave;
            MoreAcceptedOrders = data.MoreAcceptedOrders;
            for (int a = 0; a < Hoe.TooledLocations.Count; a++)
            {
                tm_base.SetTile(Hoe.TooledLocations[a], Hoe.groundAfterToolTile);
            }
            LoadInven();
            FundsText.text = Funds.ToString();
        }

        else if (Slot.instance.ActiveSlot == 2)
        {
            GameManagerSaveData data = GameManagerSaveScript.LoadGameSlotTwo();
            Funds = data.Funds;
            DaysPlayed = data.DaysPlayed;
            InventorySave = data.InventorySave;
            MoreAcceptedOrders = data.MoreAcceptedOrders;
            for (int a = 0; a < Hoe.TooledLocations.Count; a++)
            {
                tm_base.SetTile(Hoe.TooledLocations[a], Hoe.groundAfterToolTile);
            }
            LoadInven();
            FundsText.text = Funds.ToString();
        }

        else if (Slot.instance.ActiveSlot == 3)
        {
            GameManagerSaveData data = GameManagerSaveScript.LoadGameSlotThree();
            Funds = data.Funds;
            DaysPlayed = data.DaysPlayed;
            InventorySave = data.InventorySave;
            MoreAcceptedOrders = data.MoreAcceptedOrders;
            for (int a = 0; a < Hoe.TooledLocations.Count; a++)
            {
                tm_base.SetTile(Hoe.TooledLocations[a], Hoe.groundAfterToolTile);
            }
            LoadInven();
            FundsText.text = Funds.ToString();
        }

        else if (Slot.instance.ActiveSlot == 4)
        {
            GameManagerSaveData data = GameManagerSaveScript.LoadGameSlotFour();
            Funds = data.Funds;
            DaysPlayed = data.DaysPlayed;
            InventorySave = data.InventorySave;
            MoreAcceptedOrders = data.MoreAcceptedOrders;
            for (int a = 0; a < Hoe.TooledLocations.Count; a++)
            {
                tm_base.SetTile(Hoe.TooledLocations[a], Hoe.groundAfterToolTile);
            }
            LoadInven();
            FundsText.text = Funds.ToString();
        }
    }
}