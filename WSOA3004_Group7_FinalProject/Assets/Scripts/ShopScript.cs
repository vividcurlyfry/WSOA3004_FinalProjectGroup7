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
    public Text TurnipNum;
    public Text WatermelonNum;
    public Text PotatoNum;

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

    public void CheckPrices()
    {
        
    }

    public void BuyLettuce()
    {
        if (GameManagerScript.instance.Funds >= GameManagerScript.instance.LettuceSeed.CropPrice)
        {
            int pos = GameManagerScript.instance.FindPos("LettuceSeed");
            if (pos != -1)
            {
                GameManagerScript.instance.Inventory.inven[pos].ItemNumber++;
            }
            GameManagerScript.instance.DisplayInvenFunc();
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - GameManagerScript.instance.LettuceSeed.CropPrice;
            UpdateFunds();
        }
    }

    public void BuyPotato()
    {
        if (GameManagerScript.instance.Funds >= GameManagerScript.instance.PotatoSeed.CropPrice)
        {
            int pos = GameManagerScript.instance.FindPos("PotatoSeed");
            if (pos != -1)
            {
                GameManagerScript.instance.Inventory.inven[pos].ItemNumber++;
            }
            GameManagerScript.instance.DisplayInvenFunc();
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - GameManagerScript.instance.PotatoSeed.CropPrice;
            UpdateFunds();
        }
    }

    public void BuyTurnip()
    {
        if (GameManagerScript.instance.Funds >= GameManagerScript.instance.TurnipSeed.CropPrice)
        {
            int pos = GameManagerScript.instance.FindPos("TurnipSeed");
            if (pos != -1)
            {
                GameManagerScript.instance.Inventory.inven[pos].ItemNumber++;
            }
            GameManagerScript.instance.DisplayInvenFunc();
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - GameManagerScript.instance.TurnipSeed.CropPrice;
            UpdateFunds();
        }
    }

    public void BuyPeach()
    {
        if (GameManagerScript.instance.Funds >= GameManagerScript.instance.PeachSeed.CropPrice)
        {
            int pos = GameManagerScript.instance.FindPos("PeachSeed");
            if (pos != -1)
            {
                GameManagerScript.instance.Inventory.inven[pos].ItemNumber++;
            }
            GameManagerScript.instance.DisplayInvenFunc();
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - GameManagerScript.instance.PeachSeed.CropPrice;
            UpdateFunds();
        }
    }

    public void BuyWatermelon()
    {
        if (GameManagerScript.instance.Funds >= GameManagerScript.instance.WatermelonSeed.CropPrice)
        {
            int pos = GameManagerScript.instance.FindPos("WatermelonSeed");
            if (pos != -1)
            {
                GameManagerScript.instance.Inventory.inven[pos].ItemNumber++;
            }
            GameManagerScript.instance.DisplayInvenFunc();
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - GameManagerScript.instance.WatermelonSeed.CropPrice;
            UpdateFunds();
        }
    }

    public void BuyCarrot()
    {
        if (GameManagerScript.instance.Funds >= GameManagerScript.instance.CarrotSeed.CropPrice)
        {
            int pos = GameManagerScript.instance.FindPos("CarrotSeed");
            if (pos != -1)
            {
                GameManagerScript.instance.Inventory.inven[pos].ItemNumber++;
            }
            GameManagerScript.instance.DisplayInvenFunc();
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - GameManagerScript.instance.CarrotSeed.CropPrice;
            UpdateFunds();
        }
    }
    public void UpdateFunds()
    {
        GameManagerScript.instance.FundsText.text = GameManagerScript.instance.Funds.ToString();
    }
}