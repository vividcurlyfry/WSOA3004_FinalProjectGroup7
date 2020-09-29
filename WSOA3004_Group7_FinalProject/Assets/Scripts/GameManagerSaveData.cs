using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class GameManagerSaveData
{
    public int Funds;
    public int[] InventorySave;
    public int DaysPlayed;

    public GameManagerSaveData(GameManagerScript gm)
    {
        Funds = gm.Funds;
        DaysPlayed = gm.DaysPlayed;
        InventorySave = gm.InventorySave;
    }
}