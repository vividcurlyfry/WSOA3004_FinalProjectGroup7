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
    public bool hovering;

    public bool NearBed = false;

    public GameObject SelectedObj;
    public int Funds;
    public InventoryObject Inventory;
    public GameObject[] DisplayInven = new GameObject[6];
    public int[] InventorySave;
    public string[] InventoryNameSave;
    public List<int> orderListSave;
    public List<int> orderAcceptedSave;

    public Text FundsText;
    public bool isRaining;

    public Order[] orderArray;
    public List<Order> orderList;
    public List<Order> displayedOrders;
    public Order[] acceptedOrders;
    public GameObject[] juteBags;
    public GameObject[] closedJute;
    public bool[] acceptedOrderBool;
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

    public GameObject orderNotification;
    public Text orderNameText;
    public GameObject scrollView;

    public GameObject nextButt;
    public GameObject prevButt;

    public GameObject Email1;
    public GameObject Email2;
    public Text emailOrderStory1;
    public Text emailVeggiesNeeded1;
    public Text emailRewardText1;

    public Text emailOrderStory2;
    public Text emailVeggiesNeeded2;
    public Text emailRewardText2;

    public GameObject[] NoteBookOrders;
    public int activeNoteBookOrder;

    public GameObject noNotebookOrders;

    public GameObject sleepConfirmCanvas;

    public GameObject cross;
    public GameObject tick;
    public GameObject line;

    public GameObject orderDescription;

    public Text DaysOrderLeft;

    public bool dayOver = false;

    public TransitionScript transition;

    public float percentageFunds = 75 / 100;
    public bool GroceriesBought;
    public int GroceriesDays;

    public GameObject noEmail;
    public GameObject nextEmail;
    public GameObject prevEmail;
    public GameObject Failure;

    public int FailureSorting = 25;
    public Tile Sand;

    public int RubyLoop;
    public int weedNumRandom;
    public Scrollbar scrollVert;

    public List<int> LettuceDaysGrown;
    public List<int> LettucePlantedLocationsX;
    public List<int> LettucePlantedLocationsY;
    public List<int> LettucePlantedLocationsZ;
    public List<bool> LettuceWatered;

    public List<int> WatermelonDaysGrown;
    public List<int> WatermelonPlantedLocationsX;
    public List<int> WatermelonPlantedLocationsY;
    public List<int> WatermelonPlantedLocationsZ;
    public List<bool> WatermelonWatered;

    public List<int> PotatoDaysGrown;
    public List<int> PotatoPlantedLocationsX;
    public List<int> PotatoPlantedLocationsY;
    public List<int> PotatoPlantedLocationsZ;
    public List<bool> PotatoWatered;

    public List<int> CarrotDaysGrown;
    public List<int> CarrotPlantedLocationsX;
    public List<int> CarrotPlantedLocationsY;
    public List<int> CarrotPlantedLocationsZ;
    public List<bool> CarrotWatered;

    public List<int> TurnipDaysGrown;
    public List<int> TurnipPlantedLocationsX;
    public List<int> TurnipPlantedLocationsY;
    public List<int> TurnipPlantedLocationsZ;
    public List<bool> TurnipWatered;

    public string[] OrderTextSave = new string[10];
    public string[] NameOrdererSave = new string[10];
    public int[] TotalFundsSave = new int[10];
    public int[] DaysAllocatedSave = new int[10];
    public int[] DaysPassedSave = new int[10];
    public int[] RewardSave = new int[10];
    public bool[] AcceptedSave = new bool[10];
    public bool[] RejectedSave = new bool[10];
    public bool[] CompletedSave = new bool[10];
    public bool[] DeliveredSave = new bool[10];
    public int[] TurnipNeededSave = new int[10];
    public int[] WatermelonNeededSave = new int[10];
    public int[] CarrotNeededSave = new int[10];
    public int[] PotatoNeededSave = new int[10];
    public int[] LettuceNeededSave = new int[10];
    public int[] TurnipAmountSave = new int[10];
    public int[] WatermelonAmountSave = new int[10];
    public int[] CarrotAmountSave = new int[10];
    public int[] PotatoAmountSave = new int[10];
    public int[] LettuceAmountSave = new int[10];
    public int[] AcceptedOrderBoolSave = new int[10];

    public List<int> ScytheTooledX;
    public List<int> ScytheTooledY;
    public List<int> ScytheTooledZ;

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
        Failure.SetActive(false);
        isRaining = gameObject.GetComponent<LivelinessEffects>().Raining;
        NearBed = false;
        sleepConfirmCanvas.SetActive(false);
        orderDescription.SetActive(false);
        dayOver = false;
        Email2.SetActive(false);
        DisplayNotebook();
        tm_water.ClearAllTiles();
        WateringCan.TooledLocations.Clear();
        if (Slot.instance.ActiveSlot == 1 && ((PlayerPrefs.GetString("DayOnePlayedSlotOne?") != "yes") || PlayerPrefs.GetInt("SlotOneDay") == 0))
        {
            DayOne();
        }
        else if (Slot.instance.ActiveSlot == 2 && ((PlayerPrefs.GetString("DayOnePlayedSlotTwo?") != "yes") || PlayerPrefs.GetInt("SlotTwoDay") == 0))
        {
            DayOne();
        }
        else if (Slot.instance.ActiveSlot == 3 && ((PlayerPrefs.GetString("DayOnePlayedSlotThree?") != "yes") || PlayerPrefs.GetInt("SlotThreeDay") == 0))
        {
            DayOne();
        }
        else if (Slot.instance.ActiveSlot == 4 && ((PlayerPrefs.GetString("DayOnePlayedSlotFour?") != "yes") || PlayerPrefs.GetInt("SlotFourDay") == 0))
        {
            DayOne();
        }
        else
        {
            LoadGame();
            if (Scythe.TooledLocations.Count != 0)
            {
                for (int a = 0; a < Scythe.TooledLocations.Count; a++)
                {
                    tm_base.SetTile(Scythe.TooledLocations[a], Sand);
                }
            }

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
        FundsText.text = Funds.ToString();

        EmailGenerator();

        bool accepted = false;
        for (int a = 0; a < acceptedOrderBool.Length && !accepted; a++)
        {
            if (acceptedOrderBool[a] == true)
            {
                accepted = true;
            }
            else
            {
                accepted = false;
            }
        }

        if (accepted == false)
        {
            noNotebookOrders.SetActive(true);
            for (int a = 0; a < NoteBookOrders.Length; a++)
            {
                NoteBookOrders[a].SetActive(false);
                juteBags[a].SetActive(false);
            }
        }
        else
        {
            string FailureText = "";
            for (int a = 0; a < acceptedOrders.Length; a++)
            {
                if (acceptedOrderBool[a] == true)
                {
                    if (acceptedOrders[a].DaysPassed > acceptedOrders[a].DaysAllocated && !acceptedOrders[a].Completed && !acceptedOrders[a].Delivered)
                    {
                        Failure.SetActive(true);
                        FailureText += System.Environment.NewLine + "Oops! You ran out of time for " + acceptedOrders[a].nameOrder +
                        "'s order!";
                        acceptedOrders[a].OrderText = "";
                        acceptedOrders[a].nameOrder = "";
                        acceptedOrders[a].TotalFunds = 0;
                        acceptedOrders[a].DaysAllocated = 0;
                        acceptedOrders[a].DaysPassed = 0;
                        acceptedOrders[a].Reward = 0;
                        acceptedOrders[a].Accepted = false;
                        acceptedOrders[a].Rejected = false;
                        acceptedOrders[a].Completed = false;
                        acceptedOrders[a].Delivered = false;
                        acceptedOrders[a].TurnipNeeded = 0;
                        acceptedOrders[a].WatermelonNeeded = 0;
                        acceptedOrders[a].CarrotNeeded = 0;
                        acceptedOrders[a].PotatoNeeded = 0;
                        acceptedOrders[a].LettuceNeeded = 0;
                        acceptedOrders[a].TurnipAmount = 0;
                        acceptedOrders[a].WatermelonAmount = 0;
                        acceptedOrders[a].CarrotAmount = 0;
                        acceptedOrders[a].PotatoAmount = 0;
                        acceptedOrders[a].LettuceAmount = 0;
                        acceptedOrderBool[a] = false;
                        juteBags[a].SetActive(false);
                        closedJute[a].SetActive(false);
                    }
                    else if (acceptedOrders[a].Completed && acceptedOrders[a].Delivered)
                    {
                        acceptedOrders[a].OrderText = "";
                        acceptedOrders[a].nameOrder = "";
                        acceptedOrders[a].TotalFunds = 0;
                        acceptedOrders[a].DaysAllocated = 0;
                        acceptedOrders[a].DaysPassed = 0;
                        acceptedOrders[a].Reward = 0;
                        acceptedOrders[a].Accepted = false;
                        acceptedOrders[a].Rejected = false;
                        acceptedOrders[a].Completed = false;
                        acceptedOrders[a].Delivered = false;
                        acceptedOrders[a].TurnipNeeded = 0;
                        acceptedOrders[a].WatermelonNeeded = 0;
                        acceptedOrders[a].CarrotNeeded = 0;
                        acceptedOrders[a].PotatoNeeded = 0;
                        acceptedOrders[a].LettuceNeeded = 0;
                        acceptedOrders[a].TurnipAmount = 0;
                        acceptedOrders[a].WatermelonAmount = 0;
                        acceptedOrders[a].CarrotAmount = 0;
                        acceptedOrders[a].PotatoAmount = 0;
                        acceptedOrders[a].LettuceAmount = 0;
                        acceptedOrderBool[a] = false;
                        juteBags[a].SetActive(false);
                        closedJute[a].SetActive(false);
                    }
                    else
                    {
                        juteBags[a].SetActive(true);
                        closedJute[a].SetActive(false);
                    }
                }
                else
                {
                    juteBags[a].SetActive(false);
                    closedJute[a].SetActive(false);
                }

                if (acceptedOrders[a].Completed && acceptedOrders[a].Delivered)
                {
                    juteBags[a].SetActive(false);
                    closedJute[a].SetActive(false);
                }
                else if (acceptedOrders[a].Completed && !acceptedOrders[a].Delivered)
                {
                    juteBags[a].SetActive(false);
                    closedJute[a].SetActive(true);
                }
            }
            Failure.transform.Find("Name").gameObject.GetComponent<Text>().text = FailureText;
        }

        DisplayInvenFunc();
        SetupNotebook();
        DisplayNotebook();
    }

    public void SetupNotebook()
    {
        for (int k = 0; k < acceptedOrders.Length; k++)
        {
            if (acceptedOrderBool[k] && !acceptedOrders[k].Completed)
            {
                NoteBookOrders[k].transform.Find("NameOrderer").GetComponent<Text>().text = acceptedOrders[k].nameOrder;
                if ((acceptedOrders[k].DaysAllocated - acceptedOrders[k].DaysPassed) != 0)
                {
                    NoteBookOrders[k].transform.Find("DAYS").GetComponent<Text>().text = (acceptedOrders[k].DaysAllocated - acceptedOrders[k].DaysPassed).ToString();
                    NoteBookOrders[k].transform.Find("DaysLeft").gameObject.SetActive(true);
                }
                else
                {
                    NoteBookOrders[k].transform.Find("DAYS").GetComponent<Text>().text = "Due Today!";
                    NoteBookOrders[k].transform.Find("DaysLeft").gameObject.SetActive(false);
                }
                NoteBookOrders[k].transform.Find("Reward").GetComponent<Text>().text = acceptedOrders[k].Reward.ToString();
                if (acceptedOrders[k].PotatoNeeded == 0)
                {
                    NoteBookOrders[k].transform.Find("PotatoDraw").gameObject.SetActive(false);
                }
                else
                {
                    NoteBookOrders[k].transform.Find("PotatoDraw").GetComponentInChildren<Text>().text = (acceptedOrders[k].PotatoNeeded).ToString();
                    NoteBookOrders[k].transform.Find("PotatoDraw").gameObject.SetActive(true);
                }

                if (acceptedOrders[k].TurnipNeeded == 0)
                {
                    NoteBookOrders[k].transform.Find("TurnipDraw").gameObject.SetActive(false);
                }
                else
                {
                    NoteBookOrders[k].transform.Find("TurnipDraw").GetComponentInChildren<Text>().text = (acceptedOrders[k].TurnipNeeded).ToString();
                    NoteBookOrders[k].transform.Find("TurnipDraw").gameObject.SetActive(true);
                }

                if (acceptedOrders[k].CarrotNeeded == 0)
                {
                    NoteBookOrders[k].transform.Find("CarrotDraw").gameObject.SetActive(false);
                }
                else
                {
                    NoteBookOrders[k].transform.Find("CarrotDraw").GetComponentInChildren<Text>().text = (acceptedOrders[k].CarrotNeeded).ToString();
                    NoteBookOrders[k].transform.Find("CarrotDraw").gameObject.SetActive(true);
                }

                if (acceptedOrders[k].LettuceNeeded == 0)
                {
                    NoteBookOrders[k].transform.Find("LettuceDraw").gameObject.SetActive(false);
                }
                else
                {
                    NoteBookOrders[k].transform.Find("LettuceDraw").GetComponentInChildren<Text>().text = (acceptedOrders[k].LettuceNeeded).ToString();
                    NoteBookOrders[k].transform.Find("LettuceDraw").gameObject.SetActive(true);
                }

                if (acceptedOrders[k].WatermelonNeeded == 0)
                {
                    NoteBookOrders[k].transform.Find("WatermelonDraw").gameObject.SetActive(false);
                }
                else
                {
                    NoteBookOrders[k].transform.Find("WatermelonDraw").GetComponentInChildren<Text>().text = (acceptedOrders[k].WatermelonNeeded).ToString();
                    NoteBookOrders[k].transform.Find("WatermelonDraw").gameObject.SetActive(true);
                }

            }
        }
    }

    public void DisplayNotebook()
    {
        bool displayed = false;
        for (int k = 0; k < acceptedOrders.Length; k++)
        {
            NoteBookOrders[k].SetActive(false);
            noNotebookOrders.SetActive(true);
            nextButt.SetActive(false);
            prevButt.SetActive(false);
        }

        for (int k = 0; k < acceptedOrders.Length && !displayed; k++)
        {
            if (acceptedOrderBool[k] && !acceptedOrders[k].Completed)
            {
                NoteBookOrders[k].SetActive(true);
                activeNoteBookOrder = k;
                displayed = true;
                noNotebookOrders.SetActive(false);
            }
            else
            {
                NoteBookOrders[k].SetActive(false);
                displayed = false;
            }
        }

        int count = 0;
        for (int a = 0; a < acceptedOrderBool.Length; a++)
        {
            if (acceptedOrderBool[a] == true && !acceptedOrders[a].Completed)
            {
                count++;
            }
        }

        if (count <= 1)
        {
            nextButt.SetActive(false);
            prevButt.SetActive(false);
        }
        else
        {
            nextButt.SetActive(true);
            prevButt.SetActive(true);
        }
    }

    public void NextOrder()
    {
        int num = activeNoteBookOrder;
        bool displayed = false;
        for (int k = 0; k < acceptedOrders.Length; k++)
        {
            NoteBookOrders[k].SetActive(false);
        }

        int count = 0;

        for (int a = 0; a < acceptedOrderBool.Length; a++)
        {
            if (acceptedOrderBool[a] == true)
            {
                count++;
            }
        }

        if (count != 1)
        {
            if (num == acceptedOrders.Length)
            {
                num = -1;
            }
            for (int k = num + 1; k < acceptedOrders.Length && !displayed; k++)
            {
                if (k == -1)
                {
                    k = acceptedOrders.Length - 1;
                }

                if (acceptedOrderBool[k])
                {
                    NoteBookOrders[k].SetActive(true);
                    activeNoteBookOrder = k;
                    displayed = true;
                }
                else
                {
                    NoteBookOrders[k].SetActive(false);
                }

                if (k == acceptedOrders.Length - 1)
                {
                    k = -1;
                }
            }
        }
        else
        {
            NoteBookOrders[num].SetActive(true);
            activeNoteBookOrder = num;
        }
        noNotebookOrders.SetActive(false);
    }

    public void PreviousOrder()
    {
        int num = activeNoteBookOrder;
        bool displayed = false;
        for (int k = 0; k < acceptedOrders.Length; k++)
        {
            NoteBookOrders[k].SetActive(false);
        }

        int count = 0;

        for (int a = 0; a < acceptedOrderBool.Length; a++)
        {
            if (acceptedOrderBool[a] == true)
            {
                count++;
            }
        }

        if (count != 1)
        {
            if (num == 0)
            {
                num = acceptedOrders.Length;
            }
            for (int k = num - 1; k >= 0 && !displayed; k--)
            {
                if (acceptedOrderBool[k])
                {
                    NoteBookOrders[k].SetActive(true);
                    activeNoteBookOrder = k;
                    displayed = true;
                }
                else
                {
                    NoteBookOrders[k].SetActive(false);
                }

                if (k == 0 && !displayed)
                {
                    k = acceptedOrders.Length - 1;
                }
            }
        }
        else
        {
            NoteBookOrders[num].SetActive(true);
            activeNoteBookOrder = num;
        }
        noNotebookOrders.SetActive(false);
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
        Random.InitState(System.DateTime.Now.Millisecond);
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
                orderArray[l].CarrotNeeded = 0;
                orderArray[l].LettuceNeeded = 0;
                orderArray[l].PotatoNeeded = 0;
                orderArray[l].TurnipNeeded = 0;
                orderArray[l].WatermelonNeeded = 0;
                orderArray[l].DaysPassed = 0;
                orderArray[l].Completed = false;
                orderArray[l].Accepted = false;
                orderArray[l].Accepted = false;
                orderArray[l].Rejected = false;
                orderArray[l].Delivered = false;
                orderArray[l].TotalFunds = Funds;
                orderList.Add(orderArray[l]);
            }
            int ranNum = Random.Range(0, orderList.Count);
            displayedOrders.Add(orderList[ranNum]);
            orderList.Remove(orderList[ranNum]);

            int otherRanNum = Random.Range(0, orderList.Count);
            displayedOrders.Add(orderList[otherRanNum]);
            orderList.Remove(orderList[otherRanNum]);
        }
        else
        {
            int ranNum = Random.Range(0, orderList.Count);
            displayedOrders.Add(orderList[ranNum]);
            orderList.Remove(orderList[ranNum]);

            int otherRanNum = Random.Range(0, orderList.Count);
            displayedOrders.Add(orderList[otherRanNum]);
            orderList.Remove(orderList[otherRanNum]);
        }

        OrderCalc(displayedOrders[displayedOrders.Count - 1], displayedOrders[displayedOrders.Count - 2]);
        DisplayOrderEmail();
    }

    public void OrderCalc(Order order1, Order order2)
    {
        Random.InitState(System.DateTime.Now.Millisecond);
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
            totalBelowGround += order1.PotatoNeeded;
        }

        if (totalBelowGround != belowGround)
        {
            order1.TurnipNeeded = Random.Range(1, belowGround - totalBelowGround);
            totalBelowGround += order1.TurnipNeeded;
        }

        if (totalBelowGround != belowGround)
        {
            order2.CarrotNeeded = Random.Range(1, belowGround - totalBelowGround);
            totalBelowGround += order2.CarrotNeeded;
        }

        if (totalBelowGround != belowGround)
        {
            order2.PotatoNeeded = Random.Range(1, belowGround - totalBelowGround);
            totalBelowGround += order2.PotatoNeeded;
        }

        if (totalBelowGround != belowGround)
        {
            order2.TurnipNeeded = Random.Range(1, belowGround - totalBelowGround);
            totalBelowGround += order2.TurnipNeeded;
        }

        while (totalBelowGround != belowGround)
        {
            if (totalBelowGround != belowGround)
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
            totalAboveGround += order1.WatermelonNeeded;
        }

        if (totalAboveGround != aboveGround)
        {
            order2.LettuceNeeded = Random.Range(1, aboveGround - totalAboveGround);
            totalAboveGround += order2.LettuceNeeded;
        }

        if (totalAboveGround != aboveGround)
        {
            order2.WatermelonNeeded = Random.Range(1, aboveGround - totalAboveGround);
            totalAboveGround += order2.WatermelonNeeded;
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

        if (order1.LettuceNeeded == 0 && order1.WatermelonNeeded == 0)
        {
            order1.DaysAllocated = 3;
        }
        else
        {
            order1.DaysAllocated = 4;
        }

        if (order2.LettuceNeeded == 0 && order2.WatermelonNeeded == 0)
        {
            order2.DaysAllocated = 3;
        }
        else
        {
            order2.DaysAllocated = 4;
        }

    }

    public void DisplayOrderEmail()
    {
        emailOrderStory1.text = displayedOrders[0].OrderText.ToString();
        emailRewardText1.text = displayedOrders[0].Reward.ToString();

        string veggiesNeeded = "Items needed:" + System.Environment.NewLine;
        if (displayedOrders[0].CarrotNeeded != 0)
        {
            veggiesNeeded += System.Environment.NewLine + displayedOrders[0].CarrotNeeded.ToString() + " x Carrot(s)";
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

        veggiesNeeded = "Items needed:";
        if (displayedOrders[1].CarrotNeeded != 0)
        {
            veggiesNeeded += System.Environment.NewLine + displayedOrders[1].CarrotNeeded.ToString() + " x Carrot(s)";
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

        if (displayedOrders[0].Reward == 0)
        {
            Email1.SetActive(false);
            displayedOrders[0].Rejected = true;
            prevEmail.SetActive(false);
            nextEmail.SetActive(false);
            if (displayedOrders[1].Reward == 0)
            {
                Email2.SetActive(false);
                noEmail.SetActive(true);
                prevEmail.SetActive(false);
                nextEmail.SetActive(false);
                displayedOrders[1].Rejected = true;
            }
            else
            {
                Email2.SetActive(true);
                noEmail.SetActive(false);
                prevEmail.SetActive(false);
                nextEmail.SetActive(false);
            }
        }
        else
        {
            Email1.SetActive(true);
            noEmail.SetActive(false);
            prevEmail.SetActive(false);
            nextEmail.SetActive(true);
        }

        if (displayedOrders[1].Reward == 0)
        {
            Email2.SetActive(false);
            displayedOrders[1].Rejected = true;
            prevEmail.SetActive(false);
            nextEmail.SetActive(false);
        }

        if (displayedOrders[0].Reward != 0 && displayedOrders[1].Reward != 0)
        {
            Email1.SetActive(true);
            Email2.SetActive(false);
            nextEmail.SetActive(true);
            prevEmail.SetActive(false);
            displayedOrders[0].Rejected = false;
            displayedOrders[1].Rejected = false;
        }
    }

    public void nextEmailButt()
    {
        scrollVert.value = 1;
        Email2.SetActive(true);
        Email1.SetActive(false);
        prevEmail.SetActive(true);
        nextEmail.SetActive(false);
    }

    public void prevEmailButt()
    {
        scrollVert.value = 1;
        Email2.SetActive(false);
        Email1.SetActive(true);
        prevEmail.SetActive(false);
        nextEmail.SetActive(true);
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
        GroceriesBought = false;
        GroceriesDays = 1;
        PlayerPrefs.SetInt("Honey", 0);
        PlayerPrefs.SetString("HoneyDelivered", "false");
        RubyLoop = DaysPlayed % 3;

        PosInven = 0;
        for (int b = 0; b < juteBags.Length; b++)
        {
            juteBags[b].SetActive(false);
        }
        noNotebookOrders.SetActive(true);
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

        for (int a = 0; a < acceptedOrders.Length; a++)
        {
            acceptedOrders[a].OrderText = "";
            acceptedOrders[a].nameOrder = "";
            acceptedOrders[a].TotalFunds = 0;
            acceptedOrders[a].DaysAllocated = 0;
            acceptedOrders[a].DaysPassed = 0;
            acceptedOrders[a].Reward = 0;
            acceptedOrders[a].Accepted = false;
            acceptedOrders[a].Rejected = false;
            acceptedOrders[a].Completed = false;
            acceptedOrders[a].Delivered = false;
            acceptedOrders[a].TurnipNeeded = 0;
            acceptedOrders[a].WatermelonNeeded = 0;
            acceptedOrders[a].CarrotNeeded = 0;
            acceptedOrders[a].PotatoNeeded = 0;
            acceptedOrders[a].LettuceNeeded = 0;
            acceptedOrders[a].TurnipAmount = 0;
            acceptedOrders[a].WatermelonAmount = 0;
            acceptedOrders[a].CarrotAmount = 0;
            acceptedOrders[a].PotatoAmount = 0;
            acceptedOrders[a].LettuceAmount = 0;
            acceptedOrderBool[a] = false;
            juteBags[a].SetActive(false);
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
        for (int a = 0; a < Inventory.inven.Length; a++)
        {
            for(int b = 0; b < Inventory.inven.Length; b++)
            {
                if(InventoryNameSave[a] == Inventory.inven[b].ItemName)
                {
                    Inventory.inven[b].ItemNumber = InventorySave[a];
                }
            }
        }
    }

    public void SaveInven()
    {
        InventorySave = new int[Inventory.inven.Length];
        InventoryNameSave = new string[Inventory.inven.Length];
        for(int a = 0; a < Inventory.inven.Length; a++)
        {
            InventorySave[a] = Inventory.inven[a].ItemNumber;
            InventoryNameSave[a] = Inventory.inven[a].ItemName;
        }
    }

    public void LoadOrderList()
    {
        orderList.Clear();
        for (int a = 0; a < orderListSave.Count; a++)
        {
            orderList.Add(orderArray[orderListSave[a] - 1]);
        }
    }

    public void SaveOrderList()
    {
        orderListSave.Clear();
        char num;
        for (int a = 0; a < orderList.Count; a++)
        {
            num = orderList[a].name[5];
            orderListSave.Add((int)char.GetNumericValue(num));
        }
    }

    public void QuitEndDay()
    {
        GroceriesDays++;
        if (GroceriesDays == 4 && GroceriesBought)
        {
            GroceriesBought = false;
            GroceriesDays = 1;
        }

        DaysPlayed++;
        dayOver = true;
        for (int a = 0; a < acceptedOrders.Length; a++)
        {
            if (acceptedOrderBool[a] == true)
            {
                acceptedOrders[a].TotalFunds = Funds;
                acceptedOrders[a].DaysPassed++;
            }
        }
        for (int a = 0; a < LettuceSeed.PlantedLocations.Count; a++)
        {
            if (WateringCan.TooledLocations.Contains(LettuceSeed.PlantedLocations[a]) || isRaining)
            {
                LettuceSeed.Watered[a] = true;
            }
            else
            {
                LettuceSeed.Watered[a] = false;
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
            else
            {
                TurnipSeed.Watered[a] = false;
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
            else
            {
                WatermelonSeed.Watered[a] = false;
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
            else
            {
                CarrotSeed.Watered[a] = false;
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
            else
            {
                PotatoSeed.Watered[a] = false;
            }
            if (PotatoSeed.Watered[a] == true)
            {
                PotatoSeed.DaysGrown[a]++;
            }
        }

        for(int r = 0; r < acceptedOrders.Length; r++)
        {
            OrderTextSave[r] = acceptedOrders[r].OrderText;
            NameOrdererSave[r] = acceptedOrders[r].nameOrder;
            TotalFundsSave[r] = acceptedOrders[r].TotalFunds;
            DaysAllocatedSave[r] = acceptedOrders[r].DaysAllocated;
            DaysPassedSave[r] = acceptedOrders[r].DaysPassed;
            RewardSave[r] = acceptedOrders[r].Reward;
            AcceptedSave[r] = acceptedOrders[r].Accepted;
            RejectedSave[r] = acceptedOrders[r].Rejected;
            CompletedSave[r] = acceptedOrders[r].Completed;
            DeliveredSave[r] = acceptedOrders[r].Delivered;
            TurnipNeededSave[r] = acceptedOrders[r].TurnipNeeded;
            WatermelonNeededSave[r] = acceptedOrders[r].WatermelonNeeded;
            CarrotNeededSave[r] = acceptedOrders[r].CarrotNeeded;
            PotatoNeededSave[r] = acceptedOrders[r].PotatoNeeded;
            LettuceNeededSave[r] = acceptedOrders[r].LettuceNeeded;
            TurnipAmountSave[r] = acceptedOrders[r].TurnipAmount;
            WatermelonAmountSave[r] = acceptedOrders[r].WatermelonAmount;
            CarrotAmountSave[r] = acceptedOrders[r].CarrotAmount;
            PotatoAmountSave[r] = acceptedOrders[r].PotatoAmount;
            LettuceAmountSave[r] = acceptedOrders[r].LettuceAmount;
        }

        LettuceDaysGrown = LettuceSeed.DaysGrown;
        LettucePlantedLocationsX.Clear();
        LettucePlantedLocationsY.Clear();
        LettucePlantedLocationsZ.Clear();
        for (int a = 0; a < LettuceSeed.PlantedLocations.Count; a++)
        {
            LettucePlantedLocationsX.Add(LettuceSeed.PlantedLocations[a].x);
            LettucePlantedLocationsY.Add(LettuceSeed.PlantedLocations[a].y);
            LettucePlantedLocationsZ.Add(LettuceSeed.PlantedLocations[a].z);
            LettuceSeed.Watered[a] = false;
        }
        LettuceWatered = LettuceSeed.Watered;

        WatermelonDaysGrown = WatermelonSeed.DaysGrown;
        WatermelonPlantedLocationsX.Clear();
        WatermelonPlantedLocationsY.Clear();
        WatermelonPlantedLocationsZ.Clear();
        for (int a = 0; a < WatermelonSeed.PlantedLocations.Count; a++)
        {
            WatermelonPlantedLocationsX.Add(WatermelonSeed.PlantedLocations[a].x);
            WatermelonPlantedLocationsY.Add(WatermelonSeed.PlantedLocations[a].y);
            WatermelonPlantedLocationsZ.Add(WatermelonSeed.PlantedLocations[a].z);
            WatermelonSeed.Watered[a] = false;
        }
        WatermelonWatered = WatermelonSeed.Watered;

        TurnipDaysGrown = TurnipSeed.DaysGrown;
        TurnipPlantedLocationsX.Clear();
        TurnipPlantedLocationsY.Clear();
        TurnipPlantedLocationsZ.Clear();
        for (int a = 0; a < TurnipSeed.PlantedLocations.Count; a++)
        {
            TurnipPlantedLocationsX.Add(TurnipSeed.PlantedLocations[a].x);
            TurnipPlantedLocationsY.Add(TurnipSeed.PlantedLocations[a].y);
            TurnipPlantedLocationsZ.Add(TurnipSeed.PlantedLocations[a].z);
            TurnipSeed.Watered[a] = false;
        }
        TurnipWatered = TurnipSeed.Watered;

        CarrotDaysGrown = CarrotSeed.DaysGrown;
        CarrotPlantedLocationsX.Clear();
        CarrotPlantedLocationsY.Clear();
        CarrotPlantedLocationsZ.Clear();
        for (int a = 0; a < CarrotSeed.PlantedLocations.Count; a++)
        {
            CarrotPlantedLocationsX.Add(CarrotSeed.PlantedLocations[a].x);
            CarrotPlantedLocationsY.Add(CarrotSeed.PlantedLocations[a].y);
            CarrotPlantedLocationsZ.Add(CarrotSeed.PlantedLocations[a].z);
            CarrotSeed.Watered[a] = false;
        }
        CarrotWatered = CarrotSeed.Watered;

        PotatoDaysGrown = PotatoSeed.DaysGrown;
        PotatoPlantedLocationsX.Clear();
        PotatoPlantedLocationsY.Clear();
        PotatoPlantedLocationsZ.Clear();
        for (int a = 0; a < PotatoSeed.PlantedLocations.Count; a++)
        {
            PotatoPlantedLocationsX.Add(PotatoSeed.PlantedLocations[a].x);
            PotatoPlantedLocationsY.Add(PotatoSeed.PlantedLocations[a].y);
            PotatoPlantedLocationsZ.Add(PotatoSeed.PlantedLocations[a].z);
            PotatoSeed.Watered[a] = false;
        }
        PotatoWatered = PotatoSeed.Watered;

        ScytheTooledX.Clear();
        ScytheTooledY.Clear();
        ScytheTooledZ.Clear();
        for (int a = 0; a < Scythe.TooledLocations.Count; a++)
        {
            ScytheTooledX.Add(Scythe.TooledLocations[a].x);
            ScytheTooledY.Add(Scythe.TooledLocations[a].y);
            ScytheTooledZ.Add(Scythe.TooledLocations[a].z);
        }

        if (Slot.instance.ActiveSlot == 1)
        {
            PlayerPrefs.SetString("DayOnePlayedSlotOne?", "yes");
            PlayerPrefs.SetInt("SlotOneDay", DaysPlayed + 1);
            PlayerPrefs.SetInt("SlotTwoDay", PlayerPrefs.GetInt("SlotTwoDay"));
            PlayerPrefs.SetInt("SlotThreeDay", PlayerPrefs.GetInt("SlotThreeDay"));
            PlayerPrefs.SetInt("SlotFourDay", PlayerPrefs.GetInt("SlotFourDay"));
        }
        else if (Slot.instance.ActiveSlot == 2)
        {
            PlayerPrefs.SetString("DayOnePlayedSlotTwo?", "yes");
            PlayerPrefs.SetInt("SlotTwoDay", DaysPlayed + 1);
            PlayerPrefs.SetInt("SlotOneDay", PlayerPrefs.GetInt("SlotOneDay"));
            PlayerPrefs.SetInt("SlotThreeDay", PlayerPrefs.GetInt("SlotThreeDay"));
            PlayerPrefs.SetInt("SlotFourDay", PlayerPrefs.GetInt("SlotFourDay"));
        }
        else if (Slot.instance.ActiveSlot == 3)
        {
            PlayerPrefs.SetString("DayOnePlayedSlotThree?", "yes");
            PlayerPrefs.SetInt("SlotThreeDay", DaysPlayed + 1);
            PlayerPrefs.SetInt("SlotOneDay", PlayerPrefs.GetInt("SlotOneDay"));
            PlayerPrefs.SetInt("SlotTwoDay", PlayerPrefs.GetInt("SlotTwoDay"));
            PlayerPrefs.SetInt("SlotFourDay", PlayerPrefs.GetInt("SlotFourDay"));
        }
        else if (Slot.instance.ActiveSlot == 4)
        {
            PlayerPrefs.SetString("DayOnePlayedSlotFour?", "yes");
            PlayerPrefs.SetInt("SlotFourDay", DaysPlayed + 1);
            PlayerPrefs.SetInt("SlotOneDay", PlayerPrefs.GetInt("SlotOneDay"));
            PlayerPrefs.SetInt("SlotThreeDay", PlayerPrefs.GetInt("SlotThreeDay"));
            PlayerPrefs.SetInt("SlotFourDay", PlayerPrefs.GetInt("SlotFourDay"));
        }

        for (int a = 0; a < GameManagerScript.instance.acceptedOrders.Length; a++)
        {
            acceptedOrders[a].TotalFunds = Funds;
        }

        PlayerPrefs.SetString("HoneyDelivered", "false");

        SaveOrderList();
        SaveInven();
        SaveGame();
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
        QuitEndDay();

        bool deliveriesLeft = false;
        for (int a = 0; a < acceptedOrders.Length; a++)
        {
            if (acceptedOrderBool[a] == true)
            {
                if (acceptedOrders[a].Completed == true && !acceptedOrders[a].Delivered)
                {
                    deliveriesLeft = true;
                    acceptedOrders[a].Delivered = true;
                    DeliveredSave[a] = true;
                }
            }
        }

        if (Funds <= 25 && !deliveriesLeft)
        {
            PlayerPrefs.SetString("NeedHoney", "yes");
            PlayerPrefs.SetString("HoneyDelivered", "true");
            Funds = Funds + 75; 
            SaveGame();
            transition.TransitionToScene("DayOver");
        }
        else if(deliveriesLeft)
        {
            PlayerPrefs.SetString("NeedHoney", "no");
            int honey = Random.Range(50, 151);
            PlayerPrefs.SetInt("Honey", honey);

            int reward = honey;
            for (int a = 0; a < acceptedOrders.Length; a++)
            {
                if (acceptedOrders[a].Completed == true)
                {
                    reward += acceptedOrders[a].Reward;
                }
            }

            Funds = Funds + reward;
            SaveGame();
            transition.TransitionToScene("DayOver");
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
            SlotLoad(data);
        }

        else if (Slot.instance.ActiveSlot == 2)
        {
            GameManagerSaveData data = GameManagerSaveScript.LoadGameSlotTwo();
            SlotLoad(data);
        }

        else if (Slot.instance.ActiveSlot == 3)
        {
            GameManagerSaveData data = GameManagerSaveScript.LoadGameSlotThree();
            SlotLoad(data);
        }

        else if (Slot.instance.ActiveSlot == 4)
        {
            GameManagerSaveData data = GameManagerSaveScript.LoadGameSlotFour();
            SlotLoad(data);
        }
    }

    public void SlotLoad(GameManagerSaveData data)
    {
        Funds = data.Funds;
        DaysPlayed = data.DaysPlayed;
        InventorySave = data.InventorySave;
        InventoryNameSave = data.InventoryNameSave;
        orderListSave = data.orderListSave;
        acceptedOrderBool = data.acceptedOrderBool;
        GroceriesBought = data.GroceriesBought;
        GroceriesDays = data.GroceriesDays;

        LettuceDaysGrown = data.LettuceDaysGrown;
        LettucePlantedLocationsX = data.LettucePlantedLocationsX;
        LettucePlantedLocationsY = data.LettucePlantedLocationsY;
        LettucePlantedLocationsZ = data.LettucePlantedLocationsZ;
        LettuceWatered = data.LettuceWatered;

        WatermelonDaysGrown = data.WatermelonDaysGrown;
        WatermelonPlantedLocationsX = data.WatermelonPlantedLocationsX;
        WatermelonPlantedLocationsY = data.WatermelonPlantedLocationsY;
        WatermelonPlantedLocationsZ = data.WatermelonPlantedLocationsZ;
        WatermelonWatered = data.WatermelonWatered;

        TurnipDaysGrown = data.TurnipDaysGrown;
        TurnipPlantedLocationsX = data.TurnipPlantedLocationsX;
        TurnipPlantedLocationsY = data.TurnipPlantedLocationsY;
        TurnipPlantedLocationsZ = data.TurnipPlantedLocationsZ;
        TurnipWatered = data.TurnipWatered;

        CarrotDaysGrown = data.CarrotDaysGrown;
        CarrotPlantedLocationsX = data.CarrotPlantedLocationsX;
        CarrotPlantedLocationsY = data.CarrotPlantedLocationsY;
        CarrotPlantedLocationsZ = data.CarrotPlantedLocationsZ;
        CarrotWatered = data.CarrotWatered;

        PotatoDaysGrown = data.PotatoDaysGrown;
        PotatoPlantedLocationsX = data.PotatoPlantedLocationsX;
        PotatoPlantedLocationsY = data.PotatoPlantedLocationsY;
        PotatoPlantedLocationsZ = data.PotatoPlantedLocationsZ;
        PotatoWatered = data.PotatoWatered;

        LoadOrderList();
        LoadInven();
        RubyLoop = DaysPlayed % 3;

        OrderTextSave = data.OrderTextSave;
        NameOrdererSave = data.NameOrdererSave;
        TotalFundsSave = data.TotalFundsSave;
        DaysAllocatedSave = data.DaysAllocatedSave;
        DaysPassedSave = data.DaysPassedSave;
        RewardSave = data.RewardSave;
        AcceptedSave = data.AcceptedSave;
        RejectedSave = data.RejectedSave;
        CompletedSave = data.CompletedSave;
        DeliveredSave = data.DeliveredSave;
        TurnipNeededSave = data.TurnipNeededSave;
        WatermelonNeededSave = data.WatermelonNeededSave;
        CarrotNeededSave = data.CarrotNeededSave;
        PotatoNeededSave = data.PotatoNeededSave;
        LettuceNeededSave = data.LettuceNeededSave;
        TurnipAmountSave = data.TurnipAmountSave;
        WatermelonAmountSave = data.WatermelonAmountSave;
        CarrotAmountSave = data.CarrotAmountSave;
        PotatoAmountSave = data.PotatoAmountSave;
        LettuceAmountSave = data.LettuceAmountSave;

        for (int r = 0; r < acceptedOrders.Length; r++)
        {
            acceptedOrders[r].OrderText =  OrderTextSave[r];
            acceptedOrders[r].nameOrder = NameOrdererSave[r];
            acceptedOrders[r].TotalFunds = TotalFundsSave[r];
            acceptedOrders[r].DaysAllocated = DaysAllocatedSave[r];
            acceptedOrders[r].DaysPassed = DaysPassedSave[r];
            acceptedOrders[r].Reward = RewardSave[r];
            acceptedOrders[r].Accepted = AcceptedSave[r];
            acceptedOrders[r].Rejected = RejectedSave[r];
            acceptedOrders[r].Completed = CompletedSave[r];
            acceptedOrders[r].Delivered = DeliveredSave[r];
            acceptedOrders[r].TurnipNeeded = TurnipNeededSave[r];
            acceptedOrders[r].WatermelonNeeded = WatermelonNeededSave[r];
            acceptedOrders[r].CarrotNeeded = CarrotNeededSave[r];
            acceptedOrders[r].PotatoNeeded = PotatoNeededSave[r];
            acceptedOrders[r].LettuceNeeded = LettuceNeededSave[r];
            acceptedOrders[r].TurnipAmount = TurnipAmountSave[r];
            acceptedOrders[r].WatermelonAmount = WatermelonAmountSave[r];
            acceptedOrders[r].CarrotAmount = CarrotAmountSave[r];
            acceptedOrders[r].PotatoAmount = PotatoAmountSave[r];
            acceptedOrders[r].LettuceAmount = LettuceAmountSave[r];
        }

        LettuceSeed.DaysGrown = LettuceDaysGrown;
        List<Vector3Int> LettucePlantedLocations = new List<Vector3Int>();
        for(int b = 0; b < LettucePlantedLocationsX.Count; b++)
        {
            LettucePlantedLocations.Add(new Vector3Int(LettucePlantedLocationsX[b], LettucePlantedLocationsY[b], LettucePlantedLocationsZ[b]));
        }
        LettuceSeed.PlantedLocations = LettucePlantedLocations;
        LettuceSeed.Watered = LettuceWatered;

        WatermelonSeed.DaysGrown = WatermelonDaysGrown;
        List<Vector3Int> WatermelonPlantedLocations = new List<Vector3Int>();
        for (int b = 0; b < WatermelonPlantedLocationsX.Count; b++)
        {
            WatermelonPlantedLocations.Add(new Vector3Int(WatermelonPlantedLocationsX[b], WatermelonPlantedLocationsY[b], WatermelonPlantedLocationsZ[b]));
        }
        WatermelonSeed.PlantedLocations = WatermelonPlantedLocations;
        WatermelonSeed.Watered = WatermelonWatered;

        TurnipSeed.DaysGrown = TurnipDaysGrown;
        List<Vector3Int> TurnipPlantedLocations = new List<Vector3Int>();
        for (int b = 0; b < TurnipPlantedLocationsX.Count; b++)
        {
            TurnipPlantedLocations.Add(new Vector3Int(TurnipPlantedLocationsX[b], TurnipPlantedLocationsY[b], TurnipPlantedLocationsZ[b]));
        }
        TurnipSeed.PlantedLocations = TurnipPlantedLocations;
        TurnipSeed.Watered = TurnipWatered;

        CarrotSeed.DaysGrown = CarrotDaysGrown;
        List<Vector3Int> CarrotPlantedLocations = new List<Vector3Int>();
        for (int b = 0; b < CarrotPlantedLocationsX.Count; b++)
        {
            CarrotPlantedLocations.Add(new Vector3Int(CarrotPlantedLocationsX[b], CarrotPlantedLocationsY[b], CarrotPlantedLocationsZ[b]));
        }
        CarrotSeed.PlantedLocations = CarrotPlantedLocations;
        CarrotSeed.Watered = CarrotWatered;

        PotatoSeed.DaysGrown = PotatoDaysGrown;
        List<Vector3Int> PotatoPlantedLocations = new List<Vector3Int>();
        for (int b = 0; b < PotatoPlantedLocationsX.Count; b++)
        {
            PotatoPlantedLocations.Add(new Vector3Int(PotatoPlantedLocationsX[b], PotatoPlantedLocationsY[b], PotatoPlantedLocationsZ[b]));
        }
        PotatoSeed.PlantedLocations = PotatoPlantedLocations;
        PotatoSeed.Watered = PotatoWatered;

        List<Vector3Int> ScytheTooledLocations = new List<Vector3Int>();
        for (int b = 0; b < ScytheTooledX.Count; b++)
        {
            ScytheTooledLocations.Add(new Vector3Int(ScytheTooledX[b], ScytheTooledY[b], ScytheTooledZ[b]));
        }

        Scythe.TooledLocations = ScytheTooledLocations;
    }
}