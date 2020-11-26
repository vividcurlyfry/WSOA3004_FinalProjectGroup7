using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHoverDisable : MonoBehaviour
{
    public GridScript gs;
    public PlantingScript ps;

    private void OnMouseEnter()
    {
        GameManagerScript.instance.highlightedTile = new Vector3Int(-500, -500, -500);
        gs.enabled = false;
        ps.enabled = false;
    }

    private void OnMouseExit()
    {
        gs.enabled = true;
        ps.enabled = true;
    }
}
