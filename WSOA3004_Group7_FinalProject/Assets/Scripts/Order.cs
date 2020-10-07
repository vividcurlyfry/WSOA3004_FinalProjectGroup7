using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Order", menuName = "Orders")]
[System.Serializable]
public class Order : ScriptableObject
{
    public string OrderText;
    public int TurnipAmount;
    public int PeachAmount;
    public int WatermelonAmount;
    public int CarrotAmount;
    public int PotatoAmount;
    public int LettuceAmount;
}
