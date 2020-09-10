using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class InventoryScript : MonoBehaviour
{
    public InventoryClass[] Inventory;
    public GameObject[] DisplayInven = new GameObject[6];
    public GameObject highlight;

    public void Start()
    {
        DayOneInventory();
        for (int i = 0; i < 6 && i < Inventory.Length - 1; i++)
        {
            if (Inventory[i].ItemNumber > 0)
            {
                DisplayInven[i].GetComponentInChildren<Text>().text = Inventory[i].ItemNumber.ToString();
                DisplayInven[i].GetComponentInChildren<SpriteRenderer>().sprite = Inventory[i].ItemSprite;
            }
        }
    }

    public void DayOneInventory()
    {
        Inventory = new InventoryClass[6]
        {
            new InventoryClass("Hoe",1,GameManagerScript.instance.Hoe.toolSprite),
            new InventoryClass("WateringCan",0,null),
            new InventoryClass("Scythe",0,null),
            new InventoryClass("Lettuce",0,GameManagerScript.instance.Lettuce.SeedSprite),
            new InventoryClass(null,0,null),
            new InventoryClass(null,0,null)
        };
    }

    public void SelectObj(RectTransform posButton, GameObject selected)
    {
        highlight.transform.position = posButton.transform.position;
        GameManagerScript.instance.SelectedObj = selected;
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

    public void BuyLettuce()
    {
        int pos = FindPos("Lettuce");
        if (pos != -1)
        {
            Inventory[pos].ItemNumber++;
        }

        if (pos < 6)
        {
            DisplayInven[pos].transform.Find("Text").GetComponent<Text>().text = Inventory[pos].ItemNumber.ToString();
            DisplayInven[pos].GetComponentInChildren<SpriteRenderer>().sprite = GameManagerScript.instance.Lettuce.SeedSprite;
        }
    }
}
