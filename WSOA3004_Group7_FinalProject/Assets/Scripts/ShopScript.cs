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
    public Text CarrotNum;
    public Text PeachNum;
    public Text LettuceNum;

    public Text TurnipTotalPrice;
    public Text WatermelonTotalPrice;
    public Text PotatoTotalPrice;
    public Text CarrotTotalPrice;
    public Text PeachTotalPrice;
    public Text LettuceTotalPrice;


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
        if (GameManagerScript.instance.Funds >= GameManagerScript.instance.LettuceSeed.CropPrice)
        {
            int pos = GameManagerScript.instance.FindPos("LettuceSeed");
            if (pos != -1)
            {
                GameManagerScript.instance.Inventory.inven[pos].ItemNumber = GameManagerScript.instance.Inventory.inven[pos].ItemNumber + int.Parse(LettuceNum.text);
            }
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - int.Parse(LettuceTotalPrice.text);
            LettuceNum.text = "1";
            LettuceTotalPrice.text = GameManagerScript.instance.LettuceSeed.CropPrice.ToString();
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
                GameManagerScript.instance.Inventory.inven[pos].ItemNumber = GameManagerScript.instance.Inventory.inven[pos].ItemNumber + int.Parse(PotatoNum.text);
            }
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - int.Parse(PotatoTotalPrice.text);
            PotatoNum.text = "1";
            PotatoTotalPrice.text = GameManagerScript.instance.PotatoSeed.CropPrice.ToString();
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
                GameManagerScript.instance.Inventory.inven[pos].ItemNumber = GameManagerScript.instance.Inventory.inven[pos].ItemNumber + int.Parse(TurnipNum.text);
            }
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - int.Parse(TurnipTotalPrice.text);
            TurnipNum.text = "1";
            TurnipTotalPrice.text = GameManagerScript.instance.TurnipSeed.CropPrice.ToString();
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
                GameManagerScript.instance.Inventory.inven[pos].ItemNumber = GameManagerScript.instance.Inventory.inven[pos].ItemNumber + int.Parse(PeachNum.text);
            }
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - int.Parse(PeachTotalPrice.text);
            PeachNum.text = "1";
            PeachTotalPrice.text = GameManagerScript.instance.PeachSeed.CropPrice.ToString();
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
                GameManagerScript.instance.Inventory.inven[pos].ItemNumber = GameManagerScript.instance.Inventory.inven[pos].ItemNumber + int.Parse(WatermelonNum.text);
            }
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - int.Parse(WatermelonTotalPrice.text);
            WatermelonNum.text = "1";
            WatermelonTotalPrice.text = GameManagerScript.instance.WatermelonSeed.CropPrice.ToString();
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
                GameManagerScript.instance.Inventory.inven[pos].ItemNumber = GameManagerScript.instance.Inventory.inven[pos].ItemNumber + int.Parse(CarrotNum.text);
            }
            GameManagerScript.instance.Funds = GameManagerScript.instance.Funds - int.Parse(CarrotTotalPrice.text);
            CarrotNum.text = "1";
            CarrotTotalPrice.text = GameManagerScript.instance.CarrotSeed.CropPrice.ToString();
            UpdateFunds();
        }
    }
    public void UpdateFunds()
    {
        GameManagerScript.instance.FundsText.text = GameManagerScript.instance.Funds.ToString();
        GameManagerScript.instance.DisplayInvenFunc();
    }
}