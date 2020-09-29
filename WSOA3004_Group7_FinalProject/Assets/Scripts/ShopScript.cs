using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShopScript : MonoBehaviour
{
    public GameObject SeedPanel;
    public GameObject ToolPanel;
    public GameObject FoodPanel;
    public GameObject GiftPanel;

    private void Start()
    {
        ToolPanel.SetActive(false);
        FoodPanel.SetActive(false);
        GiftPanel.SetActive(false);
    }

    public void OpenSeedPanel()
    {
        SeedPanel.SetActive(true);
        ToolPanel.SetActive(false);
        FoodPanel.SetActive(false);
        GiftPanel.SetActive(false);
    }

    public void OpenToolPanel()
    {
        SeedPanel.SetActive(false);
        ToolPanel.SetActive(true);
        FoodPanel.SetActive(false);
        GiftPanel.SetActive(false);
    }

    public void OpenFoodPanel()
    {
        SeedPanel.SetActive(false);
        ToolPanel.SetActive(false);
        FoodPanel.SetActive(true);
        GiftPanel.SetActive(false);
    }

    public void OpenGiftPanel()
    {
        SeedPanel.SetActive(false);
        ToolPanel.SetActive(false);
        FoodPanel.SetActive(false);
        GiftPanel.SetActive(true);
    }

    public void BuyLettuce()
    {
        if (GameManagerScript.instance.Funds >= GameManagerScript.instance.Lettuce.CropPrice)
        {
            int pos = GameManagerScript.instance.FindPos("Lettuce");
            if (pos != -1)
            {
                GameManagerScript.instance.Inventory[pos].ItemNumber++;
            }
            GameManagerScript.instance.DisplayInvenFunc();
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - GameManagerScript.instance.Lettuce.CropPrice;
            UpdateFunds();
        }
    }

    public void BuyPotato()
    {
        if (GameManagerScript.instance.Funds >= GameManagerScript.instance.Potato.CropPrice)
        {
            int pos = GameManagerScript.instance.FindPos("Potato");
            if (pos != -1)
            {
                GameManagerScript.instance.Inventory[pos].ItemNumber++;
            }
            GameManagerScript.instance.DisplayInvenFunc();
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - GameManagerScript.instance.Potato.CropPrice;
            UpdateFunds();
        }
    }

    public void BuyTurnip()
    {
        if (GameManagerScript.instance.Funds >= GameManagerScript.instance.Turnip.CropPrice)
        {
            int pos = GameManagerScript.instance.FindPos("Turnip");
            if (pos != -1)
            {
                GameManagerScript.instance.Inventory[pos].ItemNumber++;
            }
            GameManagerScript.instance.DisplayInvenFunc();
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - GameManagerScript.instance.Turnip.CropPrice;
            UpdateFunds();
        }
    }

    public void BuyPeach()
    {
        if (GameManagerScript.instance.Funds >= GameManagerScript.instance.Peach.CropPrice)
        {
            int pos = GameManagerScript.instance.FindPos("Peach");
            if (pos != -1)
            {
                GameManagerScript.instance.Inventory[pos].ItemNumber++;
            }
            GameManagerScript.instance.DisplayInvenFunc();
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - GameManagerScript.instance.Peach.CropPrice;
            UpdateFunds();
        }
    }

    public void BuyWatermelon()
    {
        if (GameManagerScript.instance.Funds >= GameManagerScript.instance.Watermelon.CropPrice)
        {
            int pos = GameManagerScript.instance.FindPos("Watermelon");
            if (pos != -1)
            {
                GameManagerScript.instance.Inventory[pos].ItemNumber++;
            }
            GameManagerScript.instance.DisplayInvenFunc();
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - GameManagerScript.instance.Watermelon.CropPrice;
            UpdateFunds();
        }
    }

    public void BuyCarrot()
    {
        if (GameManagerScript.instance.Funds >= GameManagerScript.instance.Carrot.CropPrice)
        {
            int pos = GameManagerScript.instance.FindPos("Carrot");
            if (pos != -1)
            {
                GameManagerScript.instance.Inventory[pos].ItemNumber++;
            }
            GameManagerScript.instance.DisplayInvenFunc();
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - GameManagerScript.instance.Carrot.CropPrice;
            UpdateFunds();
        }
    }
    public void UpdateFunds()
    {
        GameManagerScript.instance.FundsText.text = GameManagerScript.instance.Funds.ToString();
    }
}