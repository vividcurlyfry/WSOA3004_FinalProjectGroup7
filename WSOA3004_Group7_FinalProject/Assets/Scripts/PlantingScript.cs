using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantingScript : MonoBehaviour
{
    public Tilemap tm_base;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite != null)
            {
                if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.Hoe.toolSprite)
                {
                    tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Hoe.groundAfterToolTile);
                }
            }
        }
    }
}
