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
    public GameObject[] DisplayInven = new GameObject[6];
    public GameObject highlight;

    public void Start()
    {
        DayOne();
        for (int a = 0; a < Lettuce.PlantedLocations.Count; a++)
        {

        }
        DisplayInvenFunc();
    }

    public void DisplayInvenFunc()
    {
        for (int i = 0; i < 6 && i < GameManagerScript.instance.Inventory.Length; i++)
        {
            if (GameManagerScript.instance.Inventory[i].ItemNumber > 0)
            {
                if ((Inventory[i].ItemName != "Hoe") && (Inventory[i].ItemName != "WateringCan"))
                {
                    DisplayInven[i].GetComponentInChildren<Text>().text = GameManagerScript.instance.Inventory[i].ItemNumber.ToString();
                }
                else
                {
                    DisplayInven[i].GetComponentInChildren<Text>().text = "";
                }
                DisplayInven[i].GetComponentInChildren<SpriteRenderer>().sprite = GameManagerScript.instance.Inventory[i].ItemSprite;
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
        GameManagerScript.instance.Inventory = new InventoryClass[6]
        {
            new InventoryClass("WateringCan",1,GameManagerScript.instance.WateringCan.toolSprite),
            new InventoryClass("Hoe",1,GameManagerScript.instance.Hoe.toolSprite),
            new InventoryClass("Lettuce",0,GameManagerScript.instance.Lettuce.SeedSprite),
            new InventoryClass("Scythe",0,null),
            new InventoryClass(null,0,null),
            new InventoryClass(null,0,null)
        };

        Funds = 250;
        Lettuce.PlantedLocations.Clear();
    }

    public void SelectObj(RectTransform posButton)
    {
        highlight.transform.position = posButton.transform.position;
        GameManagerScript.instance.SelectedObj = posButton.transform.gameObject;
    }
    public int FindPos(string name)
    {
        for (int i = 0; i < GameManagerScript.instance.Inventory.Length - 1; i++)
        {
            if (GameManagerScript.instance.Inventory[i].ItemName == name)
            {
                return i;
            }
        }
        return -1;
    }
}