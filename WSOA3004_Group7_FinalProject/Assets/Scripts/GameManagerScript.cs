using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;
    public Vector3Int highlightedTile;
    public int DaysPlayed;
    public GameObject SelectedObj;
    public int Funds;
    public InventoryObject Inventory;
    public GameObject[] DisplayInven = new GameObject[6];
    public int[] InventorySave;
    public Text FundsText;
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
    public int BuyingPrice;

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
        Debug.Log(PlayerPrefs.GetString("DayOneDone"));
        if(PlayerPrefs.GetString("DayOneDone") != "true")
        {
            DayOne();
        }
        else
        {
            LoadGame();
        }
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
    }

    public void DisplayInvenFunc()
    {
        for (int i = 0; i < Inventory.inven.Length; i++)
        {
            if (Inventory.inven[i].ItemNumber == 0)
            {
                for (int a = i; a < Inventory.inven.Length - 1; a++)
                {
                    InventoryClass tmp = Inventory.inven[a];
                   Inventory.inven[a] = Inventory.inven[a + 1];
                   Inventory.inven[a + 1] = tmp;
                }
            }
        }

        for (int i = PosInven; i < Inventory.inven.Length && i < PosInven + 6; i++)
        {
            if (Inventory.inven[i].ItemNumber > 0)
            {
                if ((Inventory.inven[i].ItemName != "Hoe") && (Inventory.inven[i].ItemName != "WateringCan") && (Inventory.inven[i].ItemName != "Scythe") && (Inventory.inven[i].ItemName != "Shovel"))
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
        Hoe.TooledLocations.Clear();
        WateringCan.TooledLocations.Clear();
        Scythe.TooledLocations.Clear();
        Shovel.TooledLocations.Clear();
        PosInven = 0;
        for (int a = 0; a < Inventory.inven.Length; a++)
        {
            if ((Inventory.inven[a].ItemName != "Hoe") && (Inventory.inven[a].ItemName != "WateringCan") && (Inventory.inven[a].ItemName != "Scythe") && (Inventory.inven[a].ItemName != "Shovel"))
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

    public void EndDay()
    {
        DaysPlayed++;
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
        for(int a = 0; a < Hoe.TooledLocations.Count; a++)
        {
            tm_base.SetTile(Hoe.TooledLocations[a], Hoe.groundAfterToolTile);
        }
        LoadInven();
        FundsText.text = Funds.ToString();
    }
}