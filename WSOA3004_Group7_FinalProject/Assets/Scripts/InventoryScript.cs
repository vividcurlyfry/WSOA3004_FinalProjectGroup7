using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public List<ScriptableObject> Inventory;
    public GameObject[] DisplayInven = new GameObject[6];
    public GameObject highlight;
    public Crop Lettuce;

    public void SelectObj(RectTransform posButton)
    {
        highlight.transform.position = posButton.transform.position;
    }

    public void BuyLettuce()
    {
        Inventory.Add(Lettuce);
        if(Inventory.Count < 7)
        {
            Debug.Log(Inventory);
            DisplayInven[Inventory.Count - 1].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Lettuce.SeedSprite;
        }
    }
}
