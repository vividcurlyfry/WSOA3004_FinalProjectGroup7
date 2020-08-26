using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public int numSquares;
    public GameObject square;

    private void Start()
    {
        for (int i = 0; i < numSquares; i++)
        {
            GameObject.Instantiate(square, new Vector3(i, 0, 0), Quaternion.identity);
        }
    }

    public void DrawSquares()
    {
        for (int i = 0; i < numSquares; i++)
        {
            GameObject.Instantiate(square, new Vector3(i, 0, 0), Quaternion.identity);
        }
    }

    public void SaveSquare()
    {
        SaveScript.SaveSquare(this);
    }

    public void LoadSquare()
    {
        SavingDataTest data = SaveScript.LoadSquare();
        numSquares = data.numSquares;
    }

    public void IncNumSquares()
    {
        numSquares++;
        DrawSquares();
    }
}
