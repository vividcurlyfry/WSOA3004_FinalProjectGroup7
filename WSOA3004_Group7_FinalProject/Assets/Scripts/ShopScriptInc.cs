using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScriptInc : MonoBehaviour
{
    public Text numItem;
    
    public void IncText()
    {
        numItem.text = (int.Parse(numItem.text) + 1).ToString();
    }

    public void DecText()
    {
        numItem.text = (int.Parse(numItem.text) - 1).ToString();
    }
}
