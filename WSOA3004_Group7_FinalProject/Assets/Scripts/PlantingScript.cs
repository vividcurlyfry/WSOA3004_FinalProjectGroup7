using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantingScript : MonoBehaviour
{
    public Tile grass;
    public bool isRaining;
    public Tile Sand;
    public int posList;
    private void Start()
    {
        isRaining = gameObject.GetComponent<LivelinessEffects>().Raining;
    }

    private void Update()
    {
        Tilemap tm_base = GameManagerScript.instance.tm_base;
        Tilemap tm_water = GameManagerScript.instance.tm_water;
        if (Input.GetMouseButtonDown(0) && GameManagerScript.instance.highlightedTile != new Vector3Int(-500, -500, -500))
        {
            if(tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.LettuceSeed.GrowingTiles[GameManagerScript.instance.LettuceSeed.DaysToGrow])
            {
                tm_base.SetTile(GameManagerScript.instance.highlightedTile, Sand);
                posList = GameManagerScript.instance.LettuceSeed.PlantedLocations.IndexOf(GameManagerScript.instance.highlightedTile);
                GameManagerScript.instance.LettuceSeed.PlantedLocations.RemoveAt(posList);
                GameManagerScript.instance.LettuceSeed.DaysGrown.RemoveAt(posList);
                GameManagerScript.instance.LettuceSeed.Watered.RemoveAt(posList);
                GameManagerScript.instance.Hoe.TooledLocations.Remove(GameManagerScript.instance.highlightedTile);
                int pos = GameManagerScript.instance.FindPos("Lettuce");
                if (pos != -1)
                {
                    GameManagerScript.instance.Inventory.inven[pos].ItemNumber++;
                }
                GameManagerScript.instance.DisplayInvenFunc();
                return;
            }
            else if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.TurnipSeed.GrowingTiles[GameManagerScript.instance.TurnipSeed.DaysToGrow])
            {
                tm_base.SetTile(GameManagerScript.instance.highlightedTile, Sand);
                posList = GameManagerScript.instance.TurnipSeed.PlantedLocations.IndexOf(GameManagerScript.instance.highlightedTile);
                GameManagerScript.instance.TurnipSeed.PlantedLocations.RemoveAt(posList);
                GameManagerScript.instance.TurnipSeed.DaysGrown.RemoveAt(posList);
                GameManagerScript.instance.TurnipSeed.Watered.RemoveAt(posList);
                GameManagerScript.instance.Hoe.TooledLocations.Remove(GameManagerScript.instance.highlightedTile);
                int pos = GameManagerScript.instance.FindPos("Turnip");
                if (pos != -1)
                {
                    GameManagerScript.instance.Inventory.inven[pos].ItemNumber++;
                }
                GameManagerScript.instance.DisplayInvenFunc();
                return;
            }
            else if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.PotatoSeed.GrowingTiles[GameManagerScript.instance.PotatoSeed.DaysToGrow])
            {
                tm_base.SetTile(GameManagerScript.instance.highlightedTile, Sand);
                posList = GameManagerScript.instance.PotatoSeed.PlantedLocations.IndexOf(GameManagerScript.instance.highlightedTile);
                GameManagerScript.instance.PotatoSeed.PlantedLocations.RemoveAt(posList);
                GameManagerScript.instance.PotatoSeed.DaysGrown.RemoveAt(posList);
                GameManagerScript.instance.PotatoSeed.Watered.RemoveAt(posList);
                GameManagerScript.instance.Hoe.TooledLocations.Remove(GameManagerScript.instance.highlightedTile);
                int pos = GameManagerScript.instance.FindPos("Potato");
                if (pos != -1)
                {
                    GameManagerScript.instance.Inventory.inven[pos].ItemNumber++;
                }
                GameManagerScript.instance.DisplayInvenFunc();
                return;
            }
            else if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.CarrotSeed.GrowingTiles[GameManagerScript.instance.CarrotSeed.DaysToGrow])
            {
                tm_base.SetTile(GameManagerScript.instance.highlightedTile, Sand);
                posList = GameManagerScript.instance.CarrotSeed.PlantedLocations.IndexOf(GameManagerScript.instance.highlightedTile);
                GameManagerScript.instance.CarrotSeed.PlantedLocations.RemoveAt(posList);
                GameManagerScript.instance.CarrotSeed.DaysGrown.RemoveAt(posList);
                GameManagerScript.instance.CarrotSeed.Watered.RemoveAt(posList);
                GameManagerScript.instance.Hoe.TooledLocations.Remove(GameManagerScript.instance.highlightedTile);
                int pos = GameManagerScript.instance.FindPos("Carrot");
                if (pos != -1)
                {
                    GameManagerScript.instance.Inventory.inven[pos].ItemNumber++;
                }
                GameManagerScript.instance.DisplayInvenFunc();
                return;
            }
            else if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.WatermelonSeed.GrowingTiles[GameManagerScript.instance.WatermelonSeed.DaysToGrow])
            {
                tm_base.SetTile(GameManagerScript.instance.highlightedTile, Sand);
                posList = GameManagerScript.instance.WatermelonSeed.PlantedLocations.IndexOf(GameManagerScript.instance.highlightedTile);
                GameManagerScript.instance.WatermelonSeed.PlantedLocations.RemoveAt(posList);
                GameManagerScript.instance.WatermelonSeed.DaysGrown.RemoveAt(posList);
                GameManagerScript.instance.WatermelonSeed.Watered.RemoveAt(posList);
                GameManagerScript.instance.Hoe.TooledLocations.Remove(GameManagerScript.instance.highlightedTile);
                int pos = GameManagerScript.instance.FindPos("Watermelon");
                if (pos != -1)
                {
                    GameManagerScript.instance.Inventory.inven[pos].ItemNumber++;
                }
                GameManagerScript.instance.DisplayInvenFunc();
                return;
            }

            if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite != null)
            {
                if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.Hoe.toolSprite && tm_base.GetTile(GameManagerScript.instance.highlightedTile) != grass)
                {
                    tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Hoe.groundAfterToolTile);
                    if (isRaining)
                    {
                        tm_water.SetTile(GameManagerScript.instance.highlightedTile,GameManagerScript.instance.Watered);
                    }
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
                    GameManagerScript.instance.WateringCan.TooledLocations.Add(GameManagerScript.instance.highlightedTile);
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.LettuceSeed.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.LettuceSeed.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.LettuceSeed.GrowingTiles[0]);
                        if (isRaining)
                        {
                            tm_water.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Watered);
                        }

                        int pos = GameManagerScript.instance.FindPos("LettuceSeed");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                            GameManagerScript.instance.LettuceSeed.PlantedLocations.Add(GameManagerScript.instance.highlightedTile);
                            GameManagerScript.instance.LettuceSeed.Watered.Add(false);
                            GameManagerScript.instance.LettuceSeed.DaysGrown.Add(0);
                        }

                        if (GameManagerScript.instance.Inventory.inven[pos].ItemNumber == 0)
                        {
                            GameManagerScript.instance.DisplayInvenFunc();
                        }
                        else
                        {
                            GameManagerScript.instance.DisplayInvenFuncNoSort();
                        }
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.TurnipSeed.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.TurnipSeed.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.TurnipSeed.GrowingTiles[0]);
                        if (isRaining)
                        {
                            tm_water.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Watered);
                        }

                        int pos = GameManagerScript.instance.FindPos("TurnipSeed");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                            GameManagerScript.instance.TurnipSeed.PlantedLocations.Add(GameManagerScript.instance.highlightedTile);
                            GameManagerScript.instance.TurnipSeed.Watered.Add(false);
                            GameManagerScript.instance.TurnipSeed.DaysGrown.Add(0);
                        }

                        if (GameManagerScript.instance.Inventory.inven[pos].ItemNumber == 0)
                        {
                            GameManagerScript.instance.DisplayInvenFunc();
                        }
                        else
                        {
                            GameManagerScript.instance.DisplayInvenFuncNoSort();
                        }
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.WatermelonSeed.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.WatermelonSeed.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.WatermelonSeed.GrowingTiles[0]);
                        if (isRaining)
                        {
                            tm_water.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Watered);
                        }

                        int pos = GameManagerScript.instance.FindPos("WatermelonSeed");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                            GameManagerScript.instance.WatermelonSeed.PlantedLocations.Add(GameManagerScript.instance.highlightedTile);
                            GameManagerScript.instance.WatermelonSeed.Watered.Add(false);
                            GameManagerScript.instance.WatermelonSeed.DaysGrown.Add(0);
                        }

                        if (GameManagerScript.instance.Inventory.inven[pos].ItemNumber == 0)
                        {
                            GameManagerScript.instance.DisplayInvenFunc();
                        }
                        else
                        {
                            GameManagerScript.instance.DisplayInvenFuncNoSort();
                        }
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.PeachSeed.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.PeachSeed.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.PeachSeed.GrowingTiles[0]);
                        if (isRaining)
                        {
                            tm_water.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Watered);
                        }

                        int pos = GameManagerScript.instance.FindPos("PeachSeed");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                            GameManagerScript.instance.PeachSeed.PlantedLocations.Add(GameManagerScript.instance.highlightedTile);
                            GameManagerScript.instance.PeachSeed.Watered.Add(false);
                            GameManagerScript.instance.PeachSeed.DaysGrown.Add(0);
                        }

                        if (GameManagerScript.instance.Inventory.inven[pos].ItemNumber == 0)
                        {
                            GameManagerScript.instance.DisplayInvenFunc();
                        }
                        else
                        {
                            GameManagerScript.instance.DisplayInvenFuncNoSort();
                        }
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.PotatoSeed.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.PotatoSeed.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.PotatoSeed.GrowingTiles[0]);
                        if (isRaining)
                        {
                            tm_water.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Watered);
                        }

                        int pos = GameManagerScript.instance.FindPos("PotatoSeed");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                            GameManagerScript.instance.PotatoSeed.PlantedLocations.Add(GameManagerScript.instance.highlightedTile);
                            GameManagerScript.instance.PotatoSeed.Watered.Add(false);
                            GameManagerScript.instance.PotatoSeed.DaysGrown.Add(0);
                        }

                        if (GameManagerScript.instance.Inventory.inven[pos].ItemNumber == 0)
                        {
                            GameManagerScript.instance.DisplayInvenFunc();
                        }
                        else
                        {
                            GameManagerScript.instance.DisplayInvenFuncNoSort();
                        }
                    }
                }

                else if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.CarrotSeed.SeedSprite)
                {
                    if (tm_base.GetTile(GameManagerScript.instance.highlightedTile) == GameManagerScript.instance.CarrotSeed.RequiredGround)
                    {
                        tm_base.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.CarrotSeed.GrowingTiles[0]);
                        if (isRaining)
                        {
                            tm_water.SetTile(GameManagerScript.instance.highlightedTile, GameManagerScript.instance.Watered);
                        }

                        int pos = GameManagerScript.instance.FindPos("CarrotSeed");
                        if (pos != -1)
                        {
                            GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                            GameManagerScript.instance.CarrotSeed.PlantedLocations.Add(GameManagerScript.instance.highlightedTile);
                            GameManagerScript.instance.CarrotSeed.Watered.Add(false);
                            GameManagerScript.instance.CarrotSeed.DaysGrown.Add(0);
                        }

                        if (GameManagerScript.instance.Inventory.inven[pos].ItemNumber == 0)
                        {
                            GameManagerScript.instance.DisplayInvenFunc();
                        }
                        else
                        {
                            GameManagerScript.instance.DisplayInvenFuncNoSort();
                        }
                    }
                }
            }
        }
    }
}
