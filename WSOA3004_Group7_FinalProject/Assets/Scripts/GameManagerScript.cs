using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;
public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;
    public Vector3Int highlightedTile;
    public int DaysPlayed;
    public GameObject SelectedObj;
    public int Funds;
    public InventoryClass[] Inventory;
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
    public GameObject[] DisplayInven = new GameObject[6];
    public GameObject highlight;

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
        DayOne();
        DisplayInvenFunc();
    }

    public void DisplayInvenFunc()
    {
        for (int i = 0; i < Inventory.Length; i++)
        {
            if (Inventory[i].ItemNumber == 0)
            {
                for (int a = i; a < Inventory.Length - 1; a++)
                {
                    InventoryClass tmp = Inventory[a];
                    Inventory[a] = Inventory[a + 1];
                    Inventory[a + 1] = tmp;
                }
            }
        }

        for (int i = 0; i < 6 && i < Inventory.Length; i++)
        {
            if (Inventory[i].ItemNumber > 0)
            {
                if ((Inventory[i].ItemName != "Hoe") && (Inventory[i].ItemName != "WateringCan"))
                {
                    DisplayInven[i].GetComponentInChildren<Text>().text = Inventory[i].ItemNumber.ToString();
                }
                else
                {
                    DisplayInven[i].GetComponentInChildren<Text>().text = "";
                }
                DisplayInven[i].GetComponentInChildren<SpriteRenderer>().sprite = Inventory[i].ItemSprite;
            }
            else
            {
                DisplayInven[i].GetComponentInChildren<Text>().text = "0";
                DisplayInven[i].GetComponentInChildren<SpriteRenderer>().sprite = null;
            }
        }
    }
    public void DayOne()
    {
        Inventory = new InventoryClass[9]
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
    }

    public void SelectObj(RectTransform posButton)
    {
        highlight.transform.position = posButton.transform.position;
        SelectedObj = posButton.transform.gameObject;
    }
    public int FindPos(string name)
    {
        for (int i = 0; i < Inventory.Length - 1; i++)
        {
            if (Inventory[i].ItemName == name)
            {
                return i;
            }
        }
        return -1;
    }
}