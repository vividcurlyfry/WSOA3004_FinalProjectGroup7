using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Order", menuName = "Orders")]
[System.Serializable]
public class Order : ScriptableObject
{
    public string OrderText;

    public int TurnipNeeded;
    public int PeachNeeded;
    public int WatermelonNeeded;
    public int CarrotNeeded;
    public int PotatoNeeded;
    public int LettuceNeeded;

    public int TurnipAmount;
    public int PeachAmount;
    public int WatermelonAmount;
    public int CarrotAmount;
    public int PotatoAmount;
    public int LettuceAmount;
    public int TimeLimit;
    public int DaysPassed;
    public bool Accepted;
}
