﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class GameManagerSaveData
{
    public int Funds;
    public int[] InventorySave;
    public List<int> orderListSave;
    public List<int> orderAcceptedSave;
    public int DaysPlayed;
    public bool[] acceptedOrderBool;
    public bool GroceriesBought;
    public int GroceriesDays;

    public GameManagerSaveData(GameManagerScript gm)
    {
        Funds = gm.Funds;
        DaysPlayed = gm.DaysPlayed;
        InventorySave = gm.InventorySave;
        orderListSave = gm.orderListSave;
        orderAcceptedSave = gm.orderAcceptedSave;
        acceptedOrderBool = gm.acceptedOrderBool;
        GroceriesDays = gm.GroceriesDays;
        GroceriesBought = gm.GroceriesBought;
    }
}