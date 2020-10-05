using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantingScript : MonoBehaviour
{
    public Tile grass;
    private void Update()
    {
        Tilemap tm_base = GameManagerScript.instance.tm_base;
        Tilemap tm_water = GameManagerScript.instance.tm_water;
        if (Input.GetMouseButtonDown(0) && GameManagerScript.instance.highlightedTile != new Vector3Int(-500, -500, -500))
        {
            if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite != null)
            {
                if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.Hoe.toolSprite && tm_base.GetTile(GameManagerScript.instance.highlightedTile) != grass)
                {
                    tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Hoe.groundAfterToolTile);
                    if (!GameManagerScript.instance.Hoe.TooledLocations.Contains(GameManagerScript.instance.highlightedTile))
                    {
                        GameManagerScript.instance.Hoe.TooledLocations.Add(GameManagerScript.instance.highlightedTile);
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.Scythe.toolSprite)
                {
                    tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Scythe.groundAfterToolTile);
                    if (!GameManagerScript.instance.Scythe.TooledLocations.Contains(GameManagerScript.instance.highlightedTile))
                    {
                        GameManagerScript.instance.Scythe.TooledLocations.Add(GameManagerScript.instance.highlightedTile);
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.WateringCan.toolSprite)
                {
                    tm_water.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.WateringCan.groundAfterToolTile);
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.LettuceSeed.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.LettuceSeed.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.LettuceSeed.GrowingTiles[0]);

                        int pos = GameManagerScript.instance.FindPos("LettuceSeed");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                        }

                        GameManagerScript.instance.DisplayInvenFunc();
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.TurnipSeed.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.TurnipSeed.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.TurnipSeed.GrowingTiles[0]);

                        int pos = GameManagerScript.instance.FindPos("TurnipSeed");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                        }

                        GameManagerScript.instance.DisplayInvenFunc();
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.WatermelonSeed.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.WatermelonSeed.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.WatermelonSeed.GrowingTiles[0]);

                        int pos = GameManagerScript.instance.FindPos("WatermelonSeed");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                        }

                        GameManagerScript.instance.DisplayInvenFunc();
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.PeachSeed.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.PeachSeed.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.PeachSeed.GrowingTiles[0]);

                        int pos = GameManagerScript.instance.FindPos("PeachSeed");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                        }

                        GameManagerScript.instance.DisplayInvenFunc();
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.PotatoSeed.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.PotatoSeed.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.PotatoSeed.GrowingTiles[0]);

                        int pos = GameManagerScript.instance.FindPos("PotatoSeed");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                        }

                        GameManagerScript.instance.DisplayInvenFunc();
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.CarrotSeed.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.CarrotSeed.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.CarrotSeed.GrowingTiles[0]);

                        int pos = GameManagerScript.instance.FindPos("CarrotSeed");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                        }

                        GameManagerScript.instance.DisplayInvenFunc();
                    }
                }
            }
        }
    }
}
