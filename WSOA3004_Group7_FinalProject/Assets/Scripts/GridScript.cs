using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridScript : MonoBehaviour
{
    public GameObject square;
    public Tilemap tm_highlight;
    public Tile highlight;
    public List<Vector3Int> HighlightedTiles;
    private void OnMouseOver()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int selectedTile = tm_highlight.WorldToCell(point);
        if (!HighlightedTiles.Contains(selectedTile))
        {
            tm_highlight.SetTile(selectedTile, highlight);
            HighlightedTiles.Add(selectedTile); 
        }
    }

    private void OnMouseExit()
    {
        for(int i = 0; i < HighlightedTiles.Count; i++)
        {
            tm_highlight.SetTile(HighlightedTiles[0], null);
        }
    }
    private void Update()
    {
        if(HighlightedTiles.Count > 1)
        {
           tm_highlight.SetTile(HighlightedTiles[0], null);
           HighlightedTiles.RemoveAt(0);
        }
    }
}
