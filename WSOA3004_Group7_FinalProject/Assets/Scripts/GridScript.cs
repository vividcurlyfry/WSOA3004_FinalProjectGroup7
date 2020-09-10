using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridScript : MonoBehaviour
{
    public Tilemap tm_highlight;
    public Tile highlight;
    public List<Vector3Int> HighlightedTiles;
    public Vector3Int[] AvailableTiles;

    private void Start()
    {
        AvailableTiles = new Vector3Int[50];
    }

    private void Update()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3Int selectedTile = tm_highlight.WorldToCell(point);
        Vector3Int playerTile = tm_highlight.WorldToCell(transform.position);

        bool TileAvailable = false;
        int a = 0;
        for (int i = playerTile.x-2; i <= playerTile.x+1; i++)
        {
            for (int j = playerTile.y-1; j <= playerTile.y+2; j++, a++)
            {
                AvailableTiles[a] = new Vector3Int(i,j,0);
                if (selectedTile == AvailableTiles[a])
                {
                    TileAvailable = true;
                }
            }
        }

        if (TileAvailable == true)
        {
            if (!HighlightedTiles.Contains(selectedTile))
            {
                tm_highlight.SetTile(selectedTile, highlight);
                HighlightedTiles.Add(selectedTile);
            }
        }
        else
        {
            for (int i = 0; i < HighlightedTiles.Count; i++)
            {
                tm_highlight.SetTile(HighlightedTiles[i], null);
            }

            HighlightedTiles.Clear();
        }

        if (HighlightedTiles.Count > 1)
        {
            tm_highlight.SetTile(HighlightedTiles[0], null);
            HighlightedTiles.RemoveAt(0);
        }

        if (HighlightedTiles.Count > 0)
        {
            GameManagerScript.instance.highlightedTile = HighlightedTiles[0];
        }
        else
        {
            GameManagerScript.instance.highlightedTile = new Vector3Int(-500, -500, -500);
        }
    }
}
