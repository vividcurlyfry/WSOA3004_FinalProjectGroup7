using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShopScript : MonoBehaviour
{
    public Text FundsText;
    public GameObject SeedCanvas;
    public GameObject UtilitiesCanvas;
    public GameObject OtherCanvas;

    private void Start()
    {
        UtilitiesCanvas.SetActive(false);
        OtherCanvas.SetActive(false);
    }

    public void OpenSeedCanvas()
    {
        SeedCanvas.SetActive(true);
        UtilitiesCanvas.SetActive(false);
        OtherCanvas.SetActive(false);
    }

    public void OpenUtilitiesCanvas()
    {
        SeedCanvas.SetActive(false);
        UtilitiesCanvas.SetActive(true);
        OtherCanvas.SetActive(false);
    }

    public void OpenOtherCanvas()
    {
        SeedCanvas.SetActive(false);
        UtilitiesCanvas.SetActive(false);
        OtherCanvas.SetActive(true);
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

    public void UpdateFunds()
    {
        FundsText.text = GameManagerScript.instance.Funds.ToString();
    }
}
