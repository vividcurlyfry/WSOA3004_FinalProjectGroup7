using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManagerSaveData
{
    public int Funds;
    public InventoryClass[] Inventory;
    public int DaysPlayed;
    public Crop Lettuce;
    public Crop Potoato;
    public Crop Turnip;
    public Crop Peach;
    public Crop Watermelon;
    public Crop Carrot;
    public Tool Hoe;
    public Tool WateringCan;
    public Tool Scythe;
    public Tool Shovel;

    public GameManagerSaveData(GameManagerScript gm)
    {
        Funds = gm.Funds;
        Inventory = gm.Inventory;
        Lettuce = gm.Lettuce;
        Potoato = gm.Potato;
        Turnip = gm.Turnip;
        Peach = gm.Peach;
        Watermelon = gm.Watermelon;
        Carrot = gm.Carrot;
        Hoe = gm.Hoe;
        WateringCan = gm.WateringCan;
        Scythe = gm.Scythe;
        Shovel = gm.Shovel;
    }
}