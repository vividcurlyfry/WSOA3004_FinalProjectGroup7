using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScriptInc : MonoBehaviour
{
    public Text numItem;
    public Text totalPrice;
    public int Price;

    public void IncText()
    {
        if (int.Parse(numItem.text) != GameManagerScript.instance.Funds / Price)
        {
            numItem.text = (int.Parse(numItem.text) + 1).ToString();
            totalPrice.text = (int.Parse(numItem.text) * Price).ToString();
        }
    }

    public void DecText()
    {
        if (int.Parse(numItem.text) != 0 && int.Parse(numItem.text) !=1)
        {
            numItem.text = (int.Parse(numItem.text) - 1).ToString();
            totalPrice.text = (int.Parse(numItem.text) * Price).ToString();
        }
    }
}
