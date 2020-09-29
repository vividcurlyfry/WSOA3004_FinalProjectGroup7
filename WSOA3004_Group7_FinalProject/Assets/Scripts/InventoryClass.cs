using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryClass
{
    public string ItemName;
    public int ItemNumber;
    public Sprite ItemSprite;

    public InventoryClass(string iName,int iNumber,Sprite ISprite)
    {
        ItemName = iName;
        ItemNumber = iNumber;
        ItemSprite = ISprite;
    }
}
