using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public Text FundsText;
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
