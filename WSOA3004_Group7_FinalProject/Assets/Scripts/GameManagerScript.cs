using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;
    public Vector3Int highlightedTile;
    public GameObject SelectedObj;
    public Crop Lettuce;
    public Tool Hoe;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }        
        else if(instance != this)
        {
            Destroy(gameObject);
        }

    }
}
