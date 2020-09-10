using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantingScript : MonoBehaviour
{
    public Tilemap tm_base;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManagerScript.instance.highlightedTile != new Vector3Int(-500,-500,-500))
        {
            if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite != null)
            {
                if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.Hoe.toolSprite)
                {
                    tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Hoe.groundAfterToolTile);
                }

                if(GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.Lettuce.SeedSprite)
                {
                    if(tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.Lettuce.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Lettuce.GrowingTiles[0]);

                        int pos = GameManagerScript.instance.FindPos("Lettuce");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory[pos].ItemNumber--;
                        }

                        GameManagerScript.instance.DisplayInvenFunc();
                    }
                }
            }
        }
    }
}
