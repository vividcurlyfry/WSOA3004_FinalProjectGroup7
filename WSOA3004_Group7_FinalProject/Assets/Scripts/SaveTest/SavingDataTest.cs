using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavingDataTest
{
    public int numSquares;

    public SavingDataTest (Square square)
    {
        numSquares = square.numSquares;
    }
}
