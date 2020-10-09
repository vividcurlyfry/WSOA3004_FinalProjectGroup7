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

    public GameObject sv;
    public GameObject SelectedObj;
    public int Funds;
    public InventoryObject Inventory;
    public GameObject[] DisplayInven = new GameObject[6];
    public int[] InventorySave;
    public Text FundsText;
    public bool isRaining;

    public GameObject jute;
    public GameObject juteClosed;

    public Order order1;

    public Crop LettuceSeed;
    public Crop PotatoSeed;
    public Crop TurnipSeed;
    public Crop PeachSeed;
    public Crop WatermelonSeed;
    public Crop CarrotSeed;

    public Tool Hoe;
    public Tool WateringCan;
    public Tool Scythe;
    public Tool Shovel;

    public GameObject highlight;
    public int PosInven;

    public TileBase[] tmState;
    public Tilemap tm_base;
    public Tilemap tm_water;

    public Tile Watered;

    public bool MoreAcceptedOrders;

    public Text noteBookText;
    public GameObject orderNotification;

    public GameObject sleepConfirmCanvas;

    public GameObject cross;
    public GameObject tick;

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

    public void Start()
    {
        isRaining = gameObject.GetComponent<LivelinessEffects>().Raining;
        NearBed = false;
        sleepConfirmCanvas.SetActive(false);
        if (PlayerPrefs.GetString("DayOneDone") != "true")
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

        if(MoreAcceptedOrders == true)
        {
            orderNotification.SetActive(true);
        }
        else
        {
            orderNotification.SetActive(false);
        }

        if (order1.Accepted) 
        {
            noteBookText.text = order1.OrderText;
        }
        else
        {
            noteBookText.text = "Hmmm... I don't seem to have any orders to complete today.";
        }

        if (order1.Accepted)
        {
            if(order1.DaysPassed > order1.DaysAllocated && !order1.Completed)
            {
                jute.SetActive(false);
                order1.CarrotAmount = 0;
                order1.TurnipAmount = 0;
                order1.WatermelonAmount = 0;
                order1.PotatoAmount = 0;
                order1.LettuceAmount = 0;
                cross.SetActive(true);
                tick.SetActive(false);
            }
            else if(order1.DaysPassed > order1.DaysAllocated && order1.Completed)
            {
                jute.SetActive(false);
                tick.SetActive(true);
                cross.SetActive(false);
            }
            else
            {
                tick.SetActive(false);
                cross.SetActive(false);
            }
        }
        else
        {
            tick.SetActive(false);
            cross.SetActive(false);
            jute.SetActive(false);
        }

        if (order1.Completed)
        {
            jute.SetActive(false);
            juteClosed.SetActive(false);
            tick.SetActive(true);
        }

        juteClosed.SetActive(false);
        DisplayInvenFunc();
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
                if ((Inventory.inven[i].ItemNumber < Inventory.inven[i + 1].ItemNumber) && (Inventory.inven[i].ItemName != "Hoe") && (Inventory.inven[i].ItemName != "WateringCan") && (Inventory.inven[i].ItemName != "Scythe"))// && (Inventory.inven[i].ItemName != "Shovel"))
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
                if ((Inventory.inven[i].ItemName != "Hoe") && (Inventory.inven[i].ItemName != "WateringCan") && (Inventory.inven[i].ItemName != "Scythe"))// && (Inventory.inven[i].ItemName != "Shovel"))
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
                if ((Inventory.inven[i].ItemName != "Hoe") && (Inventory.inven[i].ItemName != "WateringCan") && (Inventory.inven[i].ItemName != "Scythe"))// && (Inventory.inven[i].ItemName != "Shovel"))
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
        PeachSeed.PlantedLocations.Clear();
        CarrotSeed.PlantedLocations.Clear();
        LettuceSeed.DaysGrown.Clear();
        PotatoSeed.DaysGrown.Clear();
        TurnipSeed.DaysGrown.Clear();
        WatermelonSeed.DaysGrown.Clear();
        PeachSeed.DaysGrown.Clear();
        CarrotSeed.DaysGrown.Clear();
        LettuceSeed.Watered.Clear();
        PotatoSeed.Watered.Clear();
        TurnipSeed.Watered.Clear();
        WatermelonSeed.Watered.Clear();
        PeachSeed.Watered.Clear();
        CarrotSeed.Watered.Clear();
        Hoe.TooledLocations.Clear();
        WateringCan.TooledLocations.Clear();
        Scythe.TooledLocations.Clear();
        Shovel.TooledLocations.Clear();
        WateringCan.TooledLocations.Clear();
        order1.CarrotAmount = 0;
        order1.LettuceAmount = 0;
        order1.PeachAmount = 0;
        order1.PotatoAmount = 0;
        order1.TurnipAmount = 0;
        order1.WatermelonAmount = 0;
        order1.DaysPassed = 0;
        order1.Completed = false;
        order1.Accepted = false;
        PosInven = 0;
        jute.gameObject.SetActive(false);
        MoreAcceptedOrders = true;
        noteBookText.text = "Hmmm... I don't seem to have any orders to complete today.";
        sv.SetActive(true);
        order1.Accepted = false;
        order1.Delivered = false;
        for (int a = 0; a < Inventory.inven.Length; a++)
        {
            if ((Inventory.inven[a].ItemName != "Hoe") && (Inventory.inven[a].ItemName != "WateringCan") && (Inventory.inven[a].ItemName != "Scythe")) //&& (Inventory.inven[a].ItemName != "Shovel"))
            {
                Inventory.inven[a].ItemNumber = 0;
            }
            else
            {
                Inventory.inven[a].ItemNumber = 1;
            }
        }
        SaveGame();
        PlayerPrefs.SetString("DayOneDone", "true");
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
        for(int a = 0; a < Inventory.inven.Length; a++)
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
        if (order1.Accepted)
        {
            order1.DaysPassed++;
        }
        for (int a = 0; a < LettuceSeed.PlantedLocations.Count; a++)
        {
            if (WateringCan.TooledLocations.Contains(LettuceSeed.PlantedLocations[a]) || isRaining)
            {
                LettuceSeed.Watered[a] = true;
            }
            if(LettuceSeed.Watered[a] == true)
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

        for (int a = 0; a < PeachSeed.PlantedLocations.Count; a++)
        {
            if (WateringCan.TooledLocations.Contains(PeachSeed.PlantedLocations[a]) || isRaining)
            {
                PeachSeed.Watered[a] = true;
            }

            if (PeachSeed.Watered[a] == true)
            {
                PeachSeed.DaysGrown[a]++;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveGame()
    {
        GameManagerSaveScript.SaveGame(this);
    }

    public void LoadGame()
    {
        GameManagerSaveData data = GameManagerSaveScript.LoadGame();
        Funds = data.Funds;
        DaysPlayed = data.DaysPlayed;
        InventorySave = data.InventorySave;
        MoreAcceptedOrders = data.MoreAcceptedOrders;
        for(int a = 0; a < Hoe.TooledLocations.Count; a++)
        {
            tm_base.SetTile(Hoe.TooledLocations[a], Hoe.groundAfterToolTile);
        }
        LoadInven();
        FundsText.text = Funds.ToString();
    }
}