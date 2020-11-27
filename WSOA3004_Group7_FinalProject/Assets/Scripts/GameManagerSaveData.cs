using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class GameManagerSaveData
{
    public int Funds;
    public int[] InventorySave;
    public string[] InventoryNameSave;
    public List<int> orderListSave;
    public List<int> orderAcceptedSave;
    public int DaysPlayed;
    public bool[] acceptedOrderBool;
    public bool GroceriesBought;
    public int GroceriesDays;

    public List<int> LettuceDaysGrown;
    public List<int> LettucePlantedLocationsX;
    public List<int> LettucePlantedLocationsY;
    public List<int> LettucePlantedLocationsZ;
    public List<bool> LettuceWatered;

    public List<int> WatermelonDaysGrown;
    public List<int> WatermelonPlantedLocationsX;
    public List<int> WatermelonPlantedLocationsY;
    public List<int> WatermelonPlantedLocationsZ;
    public List<bool> WatermelonWatered;

    public List<int> CarrotDaysGrown;
    public List<int> CarrotPlantedLocationsX;
    public List<int> CarrotPlantedLocationsY;
    public List<int> CarrotPlantedLocationsZ;
    public List<bool> CarrotWatered;

    public List<int> TurnipDaysGrown;
    public List<int> TurnipPlantedLocationsX;
    public List<int> TurnipPlantedLocationsY;
    public List<int> TurnipPlantedLocationsZ;
    public List<bool> TurnipWatered;

    public List<int> PotatoDaysGrown;
    public List<int> PotatoPlantedLocationsX;
    public List<int> PotatoPlantedLocationsY;
    public List<int> PotatoPlantedLocationsZ;
    public List<bool> PotatoWatered;

    public string[] OrderTextSave = new string[10];
    public string[] NameOrdererSave = new string[10];
    public int[] TotalFundsSave = new int[10];
    public int[] DaysAllocatedSave = new int[10];
    public int[] DaysPassedSave = new int[10];
    public int[] RewardSave = new int[10];
    public bool[] AcceptedSave = new bool[10];
    public bool[] RejectedSave = new bool[10];
    public bool[] CompletedSave = new bool[10];
    public bool[] DeliveredSave = new bool[10];
    public int[] TurnipNeededSave = new int[10];
    public int[] WatermelonNeededSave = new int[10];
    public int[] CarrotNeededSave = new int[10];
    public int[] PotatoNeededSave = new int[10];
    public int[] LettuceNeededSave = new int[10];
    public int[] TurnipAmountSave = new int[10];
    public int[] WatermelonAmountSave = new int[10];
    public int[] CarrotAmountSave = new int[10];
    public int[] PotatoAmountSave = new int[10];
    public int[] LettuceAmountSave = new int[10];

    public GameManagerSaveData(GameManagerScript gm)
    {
        Funds = gm.Funds;
        DaysPlayed = gm.DaysPlayed;
        InventorySave = gm.InventorySave;
        InventoryNameSave = gm.InventoryNameSave;
        orderListSave = gm.orderListSave;
        orderAcceptedSave = gm.orderAcceptedSave;
        acceptedOrderBool = gm.acceptedOrderBool;
        GroceriesDays = gm.GroceriesDays;
        GroceriesBought = gm.GroceriesBought;

        LettuceDaysGrown = gm.LettuceDaysGrown;
        LettucePlantedLocationsX = gm.LettucePlantedLocationsX;
        LettucePlantedLocationsY = gm.LettucePlantedLocationsY;
        LettucePlantedLocationsZ = gm.LettucePlantedLocationsZ;
        LettuceWatered = gm.LettuceWatered;

        WatermelonDaysGrown = gm.WatermelonDaysGrown;
        WatermelonPlantedLocationsX = gm.WatermelonPlantedLocationsX;
        WatermelonPlantedLocationsY = gm.WatermelonPlantedLocationsY;
        WatermelonPlantedLocationsZ = gm.WatermelonPlantedLocationsZ;
        WatermelonWatered = gm.WatermelonWatered;

        PotatoDaysGrown = gm.PotatoDaysGrown;
        PotatoPlantedLocationsX = gm.PotatoPlantedLocationsX;
        PotatoPlantedLocationsY = gm.PotatoPlantedLocationsY;
        PotatoPlantedLocationsZ = gm.PotatoPlantedLocationsZ;
        PotatoWatered = gm.PotatoWatered;

        TurnipDaysGrown = gm.TurnipDaysGrown;
        TurnipPlantedLocationsX = gm.TurnipPlantedLocationsX;
        TurnipPlantedLocationsY = gm.TurnipPlantedLocationsY;
        TurnipPlantedLocationsZ = gm.TurnipPlantedLocationsZ;
        TurnipWatered = gm.TurnipWatered;

        CarrotDaysGrown = gm.CarrotDaysGrown;
        CarrotPlantedLocationsX = gm.CarrotPlantedLocationsX;
        CarrotPlantedLocationsY = gm.CarrotPlantedLocationsY;
        CarrotPlantedLocationsZ = gm.CarrotPlantedLocationsZ;
        CarrotWatered = gm.CarrotWatered;

        OrderTextSave = gm.OrderTextSave;
        NameOrdererSave = gm.NameOrdererSave;
        TotalFundsSave = gm.TotalFundsSave;
        DaysAllocatedSave = gm.DaysAllocatedSave;
        DaysPassedSave = gm.DaysPassedSave;
        RewardSave = gm.RewardSave;
        AcceptedSave = gm.AcceptedSave;
        RejectedSave = gm.RejectedSave;
        CompletedSave = gm.CompletedSave;
        DeliveredSave = gm.DeliveredSave;
        TurnipNeededSave = gm.TurnipNeededSave;
        WatermelonNeededSave = gm.WatermelonNeededSave;
        CarrotNeededSave = gm.CarrotNeededSave;
        PotatoNeededSave = gm.PotatoNeededSave;
        LettuceNeededSave = gm.LettuceNeededSave;
        TurnipAmountSave = gm.TurnipAmountSave;
        WatermelonAmountSave = gm.WatermelonAmountSave;
        CarrotAmountSave = gm.CarrotAmountSave;
        PotatoAmountSave = gm.PotatoAmountSave;
        LettuceAmountSave = gm.LettuceAmountSave;
    }
}