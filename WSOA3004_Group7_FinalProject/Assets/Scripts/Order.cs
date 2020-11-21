using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Order", menuName = "Orders")]
[System.Serializable] 
public class Order : ScriptableObject
{
    [TextArea(20, 25)]
    public string OrderText;
    public string nameOrder;
    public int TotalFunds;
    public int DaysAllocated;
    public int DaysPassed;

    public int Reward;

    public bool Accepted;
    public bool Rejected;
    public bool Completed;

    public bool Delivered;

    public int TurnipNeeded;
    public int WatermelonNeeded;
    public int CarrotNeeded;
    public int PotatoNeeded;
    public int LettuceNeeded;

    public int TurnipAmount;
    public int WatermelonAmount;
    public int CarrotAmount;
    public int PotatoAmount;
    public int LettuceAmount;
}
