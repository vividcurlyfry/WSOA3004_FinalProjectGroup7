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

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.WateringCan.toolSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.Lettuce.GrowingTiles[0])
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.WateringCan.groundAfterToolTile);
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.Lettuce.SeedSprite)
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

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.Turnip.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.Turnip.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Turnip.GrowingTiles[0]);

                        int pos = GameManagerScript.instance.FindPos("Turnip");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory[pos].ItemNumber--;
                        }

                        GameManagerScript.instance.DisplayInvenFunc();
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.Watermelon.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.Watermelon.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Watermelon.GrowingTiles[0]);

                        int pos = GameManagerScript.instance.FindPos("Watermelon");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory[pos].ItemNumber--;
                        }

                        GameManagerScript.instance.DisplayInvenFunc();
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.Peach.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.Peach.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Peach.GrowingTiles[0]);

                        int pos = GameManagerScript.instance.FindPos("Peach");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory[pos].ItemNumber--;
                        }

                        GameManagerScript.instance.DisplayInvenFunc();
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.Potato.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.Potato.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Potato.GrowingTiles[0]);

                        int pos = GameManagerScript.instance.FindPos("Potato");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory[pos].ItemNumber--;
                        }

                        GameManagerScript.instance.DisplayInvenFunc();
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.Carrot.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.Carrot.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Carrot.GrowingTiles[0]);

                        int pos = GameManagerScript.instance.FindPos("Carrot");
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
