using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject[] InventoryArr;
    public GameObject[] DisplayInven = new GameObject[5];
    public GameObject highlight;

    private void Start()
    {
        InventoryArr = new GameObject[25];
    }

    public void SelectObj(RectTransform posButton)
    {
        highlight.transform.position = posButton.transform.position;
    }

    public BuyLettuce()
    {

    }
}
