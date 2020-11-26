using System.Collections;
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

    public List<int> ScytheTooledX;
    public List<int> ScytheTooledY;
    public List<int> ScytheTooledZ;

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

        ScytheTooledX = gm.ScytheTooledX;
        ScytheTooledY = gm.ScytheTooledY;
        ScytheTooledZ = gm.ScytheTooledZ;
    }
}