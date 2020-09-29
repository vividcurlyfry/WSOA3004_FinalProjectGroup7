using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
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
    public InventoryClass[] Inventory;
    public GameObject[] DisplayInven = new GameObject[6];
    public string[] InventorySave;
    public Text FundsText;
    public Crop Lettuce;
    public Crop Potato;
    public Crop Turnip;
    public Crop Peach;
    public Crop Watermelon;
    public Crop Carrot;
    public Tool Hoe;
    public Tool WateringCan;
    public Tool Scythe;
    public Tool Shovel;
    public GameObject highlight;
    public int PosInven;
    public TileBase[] tmState;
    public Tilemap tm_base;

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
            if ((PosInven + 6) < GameManagerScript.instance.Inventory.Length)
            {
                TabFunc();   
            }
            else if (PosInven + 6 >= GameManagerScript.instance.Inventory.Length)
            {
                PosInven = -6;
                TabFunc();
            }
        }
    }

    public void TabFunc()
    {
        if (GameManagerScript.instance.Inventory[PosInven + 6].ItemNumber != 0)
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
        for (int i = 0; i < GameManagerScript.instance.Inventory.Length; i++)
        {
            if (GameManagerScript.instance.Inventory[i].ItemNumber == 0)
            {
                for (int a = i; a < GameManagerScript.instance.Inventory.Length - 1; a++)
                {
                    InventoryClass tmp = Inventory[a];
                    GameManagerScript.instance.Inventory[a] = GameManagerScript.instance.Inventory[a + 1];
                    GameManagerScript.instance.Inventory[a + 1] = tmp;
                }
            }
        }

        for (int i = PosInven; i < GameManagerScript.instance.Inventory.Length && i < PosInven + 6; i++)
        {
            if (GameManagerScript.instance.Inventory[i].ItemNumber > 0)
            {
                if ((GameManagerScript.instance.Inventory[i].ItemName != "Hoe") && (GameManagerScript.instance.Inventory[i].ItemName != "WateringCan"))
                {
                    DisplayInven[i % 6].GetComponentInChildren<Text>().text = GameManagerScript.instance.Inventory[i].ItemNumber.ToString();
                }
                else
                {
                    DisplayInven[i % 6].GetComponentInChildren<Text>().text = "";
                }
                DisplayInven[i % 6].GetComponentInChildren<SpriteRenderer>().sprite = GameManagerScript.instance.Inventory[i].ItemSprite;
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
        GameManagerScript.instance.Inventory = new InventoryClass[9]
        {
            new InventoryClass("WateringCan",1,WateringCan.toolSprite),
            new InventoryClass("Hoe",1,Hoe.toolSprite),
            new InventoryClass("Scythe",0,null),
            new InventoryClass("Lettuce",0,Lettuce.SeedSprite),
            new InventoryClass("Potato",0,Potato.SeedSprite),
            new InventoryClass("Turnip",0,Turnip.SeedSprite),
            new InventoryClass("Peach",0,Peach.SeedSprite),
            new InventoryClass("Watermelon",0,Watermelon.SeedSprite),
            new InventoryClass("Carrot",0,Carrot.SeedSprite),
        };

        Funds = 250;
        Lettuce.PlantedLocations.Clear();
        PosInven = 0;
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
        for (int i = 0; i < GameManagerScript.instance.Inventory.Length; i++)
        {
            if (GameManagerScript.instance.Inventory[i].ItemName == name)
            {
                return i;
            }
        }
        return -1;
    }

    public void EndDay()
    {
        DaysPlayed++;
        Lettuce.DaysGrown = 15;
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
        FundsText.text = GameManagerScript.instance.Funds.ToString();
    }
}